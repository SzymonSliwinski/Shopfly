using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ApiModels;
using Common.Models.ShopModels;
using Common.Services;
using OpenWebApi.Filters;

namespace OpenWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsVariantsPhotosController : ControllerBase
    {
        private readonly AppDbContext _productsVariantsPhotosService;
        public ProductsVariantsPhotosController(AppDbContext context)
        {
            _productsVariantsPhotosService = context;
        }

        [KeyAuthenticationFilter(Table = TableType.productsVariantsPhotos, Method = HttpMethodType.get)]
        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<ProductsVariantsPhotos>> FindOne(int id)
        {
            var service = new ManyToManyCrudService<ProductsVariantsPhotos>(_productsVariantsPhotosService);
            var productsVariantsPhotos = await service.GetById(id);

            return Ok(await service.GetByKey(productsVariantsPhotos.ProductVariantId, productsVariantsPhotos.PhotoId));
        }

        [KeyAuthenticationFilter(Table = TableType.productsVariantsPhotos, Method = HttpMethodType.delete)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromBody] ProductsVariantsPhotos productsVariantsPhotos)
        {
            var service = new ManyToManyCrudService<ProductsVariantsPhotos>(_productsVariantsPhotosService);
            await service.Delete(productsVariantsPhotos.ProductVariantId, productsVariantsPhotos.PhotoId);
            return Ok();
        }

        [KeyAuthenticationFilter(Table = TableType.productsVariantsPhotos, Method = HttpMethodType.post)]
        [HttpPost]
        public async Task<ActionResult<ProductsVariantsPhotos>> Add([FromBody] ProductsVariantsPhotos productsVariantsPhotos)
        {
            var service = new ManyToManyCrudService<ProductsVariantsPhotos>(_productsVariantsPhotosService);
            return Ok(await service.Insert(productsVariantsPhotos));
        }

        [KeyAuthenticationFilter(Table = TableType.productsVariantsPhotos, Method = HttpMethodType.patch)]
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
