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
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        public OrderController(AppDbContext context)
        {
            _orderService = new OrderService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Order>> GetById(int id)
        {
            return Ok(await _orderService.GetById(id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Order>> GetAll()
        {
            return Ok(await _orderService.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> Delete(int id)
        {
            return Ok(await _orderService.Delete(id));
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Add([FromBody] Order order)
        {
            return Ok(await _orderService.Add(order));
        }

        [HttpPatch]
        public async Task<ActionResult<Order>> Update([FromBody] Order order)
        {
            return Ok(await _orderService.Update(order));
        }
    }
}
