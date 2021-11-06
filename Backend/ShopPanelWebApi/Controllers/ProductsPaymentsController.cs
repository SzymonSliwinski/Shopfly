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
    public class ProductsPaymentsController : ControllerBase
    {
        private readonly ProductsPaymentsService _productsPaymentsService;
        public ProductsPaymentsController(AppDbContext context)
        {
            _productsPaymentsService = new ProductsPaymentsService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<ProductsPayments>> FindOne(int productId, int paymentTypeId)
        {
            return Ok(await _productsPaymentsService.FindOne(productId, paymentTypeId));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductsPayments>> Delete(int productId, int paymentTypeId)
        {
            return Ok(await _productsPaymentsService.Delete(productId, paymentTypeId));
        }

        [HttpPost]
        public async Task<ActionResult<ProductsPayments>> Add([FromBody] ProductsPayments productsPayments)
        {
            return Ok(await _productsPaymentsService.Add(productsPayments));
        }

        /*        [HttpPatch]
                public async Task<ActionResult<ProductsPayments>> Update([FromBody] ProductsPayments oldProductsPayments, ProductsPayments newProductsPayments)
                {
                    return Ok(await _productsPaymentsService.Update(oldProductsPayments, newProductsPayments));
                }
        */
        [HttpPost]
        public async Task<ActionResult<ProductsPayments>> AddMany([FromBody] List<ProductsPayments> productsPaymentsList)
        {
            return Ok(await _productsPaymentsService.AddMany(productsPaymentsList));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductsPayments>> RemoveMany(List<ProductsPayments> productsPaymentsList)
        {
            return Ok(await _productsPaymentsService.RemoveMany(productsPaymentsList));
        }
    }
}
