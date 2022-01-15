using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopModels;
using Common.Services;
using ShopPanelWebApi.Filters;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    [TokenAuthenticationFilter]
    [ApiController]
    public class ProductsVariantsPhotosController : ControllerBase
    {
        private readonly AppDbContext _productsVariantsPhotosService;
        public ProductsVariantsPhotosController(AppDbContext context)
        {
            _productsVariantsPhotosService = context;
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<ProductsVariantsPhotos>> FindOne(int id) // błąd 500
        {
            var service = new ManyToManyCrudService<ProductsVariantsPhotos>(_productsVariantsPhotosService);
            var productsVariantsPhotos = await service.GetById(id);

            return Ok(await service.GetByKey(productsVariantsPhotos.ProductVariantId, productsVariantsPhotos.PhotoId));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromBody] ProductsVariantsPhotos productsVariantsPhotos)    // błąd 500
        {
            var service = new ManyToManyCrudService<ProductsVariantsPhotos>(_productsVariantsPhotosService);
            await service.Delete(productsVariantsPhotos.ProductVariantId, productsVariantsPhotos.PhotoId);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<ProductsVariantsPhotos>> Add([FromBody] ProductsVariantsPhotos productsVariantsPhotos)   // działa 
        {
            var service = new ManyToManyCrudService<ProductsVariantsPhotos>(_productsVariantsPhotosService);
            return Ok(await service.Insert(productsVariantsPhotos));
        }

        [HttpPatch]
        public async Task<ActionResult<ProductsVariantsPhotos>> Update([FromBody] ProductsVariantsPhotos updateOldModelDto) // zwraca 200, ale nie wiem czy dobrze
        {
            //var service = new ManyToManyCrudService<ProductsVariantsPhotos>(_productsVariantsPhotosService);
            await Delete(updateOldModelDto);
            await Add(updateOldModelDto);
            return Ok();
        }
    }
}
