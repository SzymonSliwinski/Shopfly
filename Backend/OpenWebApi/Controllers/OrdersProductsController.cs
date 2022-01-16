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
    public class OrdersProductsController : ControllerBase
    {
        private readonly OrdersProductsService _ordersProductsService;
        public OrdersProductsController(AppDbContext context)
        {
            _ordersProductsService = new OrdersProductsService(context);
        }

        [KeyAuthenticationFilter(Table = TableType.ordersProducts, Method = HttpMethodType.get)]
        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<OrdersProducts>> FindOne(int orderId, int productId)
        {
            return Ok(await _ordersProductsService.FindOne(orderId, productId));
        }

        [KeyAuthenticationFilter(Table = TableType.ordersProducts, Method = HttpMethodType.delete)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrdersProducts>> Delete(int orderId, int productId)
        {
            return Ok(await _ordersProductsService.Delete(orderId, productId));
        }

        [KeyAuthenticationFilter(Table = TableType.ordersProducts, Method = HttpMethodType.post)]
        [HttpPost]
        public async Task<ActionResult<OrdersProducts>> Add([FromBody] OrdersProducts ordersProducts)
        {
            return Ok(await _ordersProductsService.Add(ordersProducts));
        }

        [KeyAuthenticationFilter(Table = TableType.ordersProducts, Method = HttpMethodType.patch)]
        [HttpPatch]
        public async Task<ActionResult<OrdersProducts>> Update([FromBody] UpdateModelDto<OrdersProducts> payload)
        {
            return Ok(await _ordersProductsService.Update(payload));
        }

        [KeyAuthenticationFilter(Table = TableType.ordersProducts, Method = HttpMethodType.post)]
        [HttpPost]
        public async Task<ActionResult<OrdersProducts>> AddMany([FromBody] List<OrdersProducts> ordersProductsList)
        {
            return Ok(await _ordersProductsService.AddMany(ordersProductsList));
        }

        [KeyAuthenticationFilter(Table = TableType.ordersProducts, Method = HttpMethodType.delete)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrdersProducts>> RemoveMany(List<OrdersProducts> ordersProductsList)
        {
            return Ok(await _ordersProductsService.RemoveMany(ordersProductsList));
        }
    }
}
