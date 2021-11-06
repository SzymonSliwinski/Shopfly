using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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
    public class ProductsTagsController : ControllerBase
    {
        private readonly ProductsTagsService _productsTagsService;
        public ProductsTagsController(AppDbContext context)
        {
            _productsTagsService = new ProductsTagsService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<ProductsTags>> FindOne(int tagId, int productId)
        {
            return Ok(await _productsTagsService.FindOne(tagId, productId));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductsTags>> Delete(int tagId, int productId)
        {
            return Ok(await _productsTagsService.Delete(tagId, productId));
        }

        [HttpPost]
        public async Task<ActionResult<ProductsTags>> Add([FromBody] ProductsTags productsTags)
        {
            return Ok(await _productsTagsService.Add(productsTags));
        }

        /*       [HttpPatch]
               public async Task<ActionResult<ProductsTags>> Update([FromBody] ProductsTags newProductsTags)
               {
                   return Ok(await _productsTagsService.Update(newProductsTags));
               }*/

        [HttpPost]
        public async Task<ActionResult<ProductsTags>> AddMany([FromBody] List<ProductsTags> productsTagsList)
        {
            return Ok(await _productsTagsService.AddMany(productsTagsList));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductsTags>> RemoveMany(List<ProductsTags> productsTagsList)
        {
            return Ok(await _productsTagsService.RemoveMany(productsTagsList));
        }
    }
}
