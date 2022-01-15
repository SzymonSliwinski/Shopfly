using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
    public class ProductsCarriersController : ControllerBase
    {
        private readonly ProductsCarriersService _productsCarriersService;
        public ProductsCarriersController(AppDbContext context)
        {
            _productsCarriersService = new ProductsCarriersService(context);
        }

        [KeyAuthenticationFilter(Table = TableType.productsCarriers, Method = HttpMethodType.get)]
        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<ProductsCarriers>> FindOne(int productId, int carrierId)
        {
            return Ok(await _productsCarriersService.FindOne(productId, carrierId));
        }

        [KeyAuthenticationFilter(Table = TableType.productsCarriers, Method = HttpMethodType.delete)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductsCarriers>> Delete(int productId, int carrierId)
        {
            return Ok(await _productsCarriersService.Delete(productId, carrierId));
        }

        [KeyAuthenticationFilter(Table = TableType.productsCarriers, Method = HttpMethodType.post)]
        [HttpPost]
        public async Task<ActionResult<ProductsCarriers>> Add([FromBody] ProductsCarriers productsCarriers)
        {
            return Ok(await _productsCarriersService.Add(productsCarriers));
        }

        [KeyAuthenticationFilter(Table = TableType.productsCarriers, Method = HttpMethodType.patch)]
        [HttpPatch]
        public async Task<ActionResult<ProductsCarriers>> Update([FromBody] UpdateModelDto<ProductsCarriers> payload)
        {
            return Ok(await _productsCarriersService.Update(payload));
        }

        [KeyAuthenticationFilter(Table = TableType.productsCarriers, Method = HttpMethodType.post)]
        [HttpPost]
        public async Task<ActionResult<ProductsCarriers>> AddMany([FromBody] List<ProductsCarriers> productsCarriersList)
        {
            return Ok(await _productsCarriersService.AddMany(productsCarriersList));
        }

        [KeyAuthenticationFilter(Table = TableType.productsCarriers, Method = HttpMethodType.delete)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductsCarriers>> RemoveMany(List<ProductsCarriers> productsCarriersList)
        {
            return Ok(await _productsCarriersService.RemoveMany(productsCarriersList));
        }
    }
}
