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
    public class OrdersProductsController : ControllerBase
    {
        private readonly OrdersProductsService _ordersProductsService;
        public OrdersProductsController(AppDbContext context)
        {
            _ordersProductsService = new OrdersProductsService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<OrdersProducts>> FindOne(int orderId, int productId)
        {
            return Ok(await _ordersProductsService.FindOne(orderId, productId));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OrdersProducts>> Delete(int orderId, int productId)
        {
            return Ok(await _ordersProductsService.Delete(orderId, productId));
        }

        [HttpPost]
        public async Task<ActionResult<OrdersProducts>> Add([FromBody] OrdersProducts ordersProducts)
        {
            return Ok(await _ordersProductsService.Add(ordersProducts));
        }

        [HttpPatch]
        public async Task<ActionResult<OrdersProducts>> Update([FromBody] UpdateModelDto<OrdersProducts> payload)
        {
            return Ok(await _ordersProductsService.Update(payload));
        }

        [HttpPost]
        public async Task<ActionResult<OrdersProducts>> AddMany([FromBody] List<OrdersProducts> ordersProductsList)
        {
            return Ok(await _ordersProductsService.AddMany(ordersProductsList));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OrdersProducts>> RemoveMany(List<OrdersProducts> ordersProductsList)
        {
            return Ok(await _ordersProductsService.RemoveMany(ordersProductsList));
        }
    }
}
