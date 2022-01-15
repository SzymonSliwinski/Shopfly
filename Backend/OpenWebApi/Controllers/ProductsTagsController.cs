using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Dtos;
using Common.Models.ApiModels;
using Common.Models.ShopModels;
using Common.Services;
using OpenWebApi.Filters;

namespace OpenWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsTagsController : ControllerBase
    {
        private readonly ProductsTagsService _productsTagsService;
        public ProductsTagsController(AppDbContext context)
        {
            _productsTagsService = new ProductsTagsService(context);
        }

        [KeyAuthenticationFilter(Table = TableType.productTags, Method = HttpMethodType.get)]
        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<ProductsTags>> FindOne(int tagId, int productId)
        {
            return Ok(await _productsTagsService.FindOne(tagId, productId));
        }

        [KeyAuthenticationFilter(Table = TableType.productTags, Method = HttpMethodType.delete)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductsTags>> Delete(int tagId, int productId)
        {
            return Ok(await _productsTagsService.Delete(tagId, productId));
        }

        [KeyAuthenticationFilter(Table = TableType.productTags, Method = HttpMethodType.post)]
        [HttpPost]
        public async Task<ActionResult<ProductsTags>> Add([FromBody] ProductsTags productsTags)
        {
            return Ok(await _productsTagsService.Add(productsTags));
        }

        [KeyAuthenticationFilter(Table = TableType.productTags, Method = HttpMethodType.patch)]
        [HttpPatch]
        public async Task<ActionResult<ProductsTags>> Update([FromBody] UpdateModelDto<ProductsTags> payload)
        {
            return Ok(await _productsTagsService.Update(payload));
        }

        [KeyAuthenticationFilter(Table = TableType.productTags, Method = HttpMethodType.post)]
        [HttpPost]
        public async Task<ActionResult<ProductsTags>> AddMany([FromBody] List<ProductsTags> productsTagsList)
        {
            return Ok(await _productsTagsService.AddMany(productsTagsList));
        }

        [KeyAuthenticationFilter(Table = TableType.productTags, Method = HttpMethodType.delete)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductsTags>> RemoveMany(List<ProductsTags> productsTagsList)
        {
            return Ok(await _productsTagsService.RemoveMany(productsTagsList));
        }
    }
}
