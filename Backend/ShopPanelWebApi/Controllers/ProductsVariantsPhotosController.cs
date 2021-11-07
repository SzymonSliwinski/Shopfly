using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Common.Dtos;
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
        private readonly ProductsVariantsPhotosService _productsVariantsPhotosService;
        public ProductsVariantsPhotosController(AppDbContext context)
        {
            _productsVariantsPhotosService = new ProductsVariantsPhotosService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<ProductsVariantsPhotos>> FindOne(int productVariantId, int photoId)
        {
            return Ok(await _productsVariantsPhotosService.FindOne(productVariantId, photoId));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductsVariantsPhotos>> Delete(int productVariantId, int photoId)
        {
            return Ok(await _productsVariantsPhotosService.Delete(productVariantId, photoId));
        }

        [HttpPost]
        public async Task<ActionResult<ProductsVariantsPhotos>> Add([FromBody] ProductsVariantsPhotos productsVariantsPhotos)
        {
            return Ok(await _productsVariantsPhotosService.Add(productsVariantsPhotos));
        }

        [HttpPatch]
        public async Task<ActionResult<ProductsVariantsPhotos>> Update([FromBody] UpdateModelDto<ProductsVariantsPhotos> payload)
        {
            return Ok(await _productsVariantsPhotosService.Update(payload));
        }

        [HttpPost]
        public async Task<ActionResult<ProductsVariantsPhotos>> AddMany([FromBody] List<ProductsVariantsPhotos> productsVariantsPhotosList)
        {
            return Ok(await _productsVariantsPhotosService.AddMany(productsVariantsPhotosList));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductsVariantsPhotos>> RemoveMany(List<ProductsVariantsPhotos> productsVariantsPhotosList)
        {
            return Ok(await _productsVariantsPhotosService.RemoveMany(productsVariantsPhotosList));
        }
    }
}
