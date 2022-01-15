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
    public class ProductsPaymentsController : ControllerBase
    {
        private readonly ProductsPaymentsService _productsPaymentsService;
        public ProductsPaymentsController(AppDbContext context)
        {
            _productsPaymentsService = new ProductsPaymentsService(context);
        }

        [KeyAuthenticationFilter(Table = TableType.productsPayments, Method = HttpMethodType.get)]
        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<ProductsPayments>> FindOne(int productId, int paymentTypeId)
        {
            return Ok(await _productsPaymentsService.FindOne(productId, paymentTypeId));
        }

        [KeyAuthenticationFilter(Table = TableType.productsPayments, Method = HttpMethodType.delete)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductsPayments>> Delete(int productId, int paymentTypeId)
        {
            return Ok(await _productsPaymentsService.Delete(productId, paymentTypeId));
        }

        [KeyAuthenticationFilter(Table = TableType.productsPayments, Method = HttpMethodType.post)]
        [HttpPost]
        public async Task<ActionResult<ProductsPayments>> Add([FromBody] ProductsPayments productsPayments)
        {
            return Ok(await _productsPaymentsService.Add(productsPayments));
        }

        [KeyAuthenticationFilter(Table = TableType.productsPayments, Method = HttpMethodType.patch)]
        [HttpPatch]
        public async Task<ActionResult<ProductsPayments>> Update([FromBody] UpdateModelDto<ProductsPayments> payload)
        {
            return Ok(await _productsPaymentsService.Update(payload));
        }

        [KeyAuthenticationFilter(Table = TableType.productsPayments, Method = HttpMethodType.post)]
        [HttpPost]
        public async Task<ActionResult<ProductsPayments>> AddMany([FromBody] List<ProductsPayments> productsPaymentsList)
        {
            return Ok(await _productsPaymentsService.AddMany(productsPaymentsList));
        }

        [KeyAuthenticationFilter(Table = TableType.productsPayments, Method = HttpMethodType.delete)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductsPayments>> RemoveMany(List<ProductsPayments> productsPaymentsList)
        {
            return Ok(await _productsPaymentsService.RemoveMany(productsPaymentsList));
        }
    }
}
