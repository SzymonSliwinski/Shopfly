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
    public class ProductsCarriersController : ControllerBase
    {
        private readonly ProductsCarriersService _productsCarriersService;
        public ProductsCarriersController(AppDbContext context)
        {
            _productsCarriersService = new ProductsCarriersService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<ProductsCarriers>> FindOne(int productId, int carrierId)
        {
            return Ok(await _productsCarriersService.FindOne(productId, carrierId));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductsCarriers>> Delete(int productId, int carrierId)
        {
            return Ok(await _productsCarriersService.Delete(productId, carrierId));
        }

        [HttpPost]
        public async Task<ActionResult<ProductsCarriers>> Add([FromBody] ProductsCarriers productsCarriers)
        {
            return Ok(await _productsCarriersService.Add(productsCarriers));
        }

        /*        [HttpPatch]
                public async Task<ActionResult<ProductsCarriers>> Update([FromBody] ProductsCarriers oldProductsCarriers, ProductsCarriers newProductsCarriers)
                {
                    return Ok(await _productsCarriersService.Update(oldProductsCarriers, newProductsCarriers));
                }*/

        [HttpPost]
        public async Task<ActionResult<ProductsCarriers>> AddMany([FromBody] List<ProductsCarriers> productsCarriersList)
        {
            return Ok(await _productsCarriersService.AddMany(productsCarriersList));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductsCarriers>> RemoveMany(List<ProductsCarriers> productsCarriersList)
        {
            return Ok(await _productsCarriersService.RemoveMany(productsCarriersList));
        }
    }
}
