using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopModels;
using Common.Services;
using ShopPanelWebApi.Filters;
using ShopPanelWebApi.Dtos;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    [TokenAuthenticationFilter]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;
        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Order>> GetById(int id)
        {
            var service = new CrudService<Order>(_context);
            var order = await service.GetById(id);

            return Ok(await service.GetById(order.Id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Order>> GetAll()
        {
            var service = new CrudService<Order>(_context);
            return Ok(await service.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> Delete(int id)
        {
            var service = new CrudService<Order>(_context);
            var order = await service.GetById(id);

            order.IsActive = false;

            await service.Update(order);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Add([FromBody] Order order)
        {
            var service = new CrudService<Order>(_context);

            order.Date = DateTime.Now.ToLocalTime();
            order.AdditionalDescription = order.AdditionalDescription.Trim();
            order.IsActive = true;

            order.DeliveryAddressStreet = order.DeliveryAddressStreet.Trim();
            order.DeliveryAddressPostal = order.DeliveryAddressPostal.Trim();
            order.DeliveryAddressCity = order.DeliveryAddressCity.Trim();
            order.DeliveryAddressCountry = order.DeliveryAddressCountry.Trim();

            order.BillingAddressStreet = order.BillingAddressStreet.Trim();
            order.BillingAddressPostal = order.BillingAddressPostal.Trim();
            order.BillingAddressCity = order.BillingAddressCity.Trim();
            order.BillingAddressCountry = order.BillingAddressCountry.Trim();

            order.Nip = order.Nip.Trim();
            order.CompanyName = order.CompanyName.Trim();
            order.CustomerPhoneNumber = order.CustomerPhoneNumber.Trim();
            order.CustomerEmail = order.CustomerEmail.Trim();

            return Ok(await service.Insert(order));
        }

        [HttpPatch]
        public async Task<ActionResult<Order>> Update([FromBody] Order updatedOrder)
        {
            var service = new CrudService<Order>(_context);
            var oldOrder = await service.GetById(updatedOrder.Id);

            return Ok(await service.Update(oldOrder));
        }

        [HttpGet("get-view-data")]
        public async Task<ActionResult<ViewDto>> GetViewData()
        {
            var result = new ViewDto()
            {
                NewOrdersToday = await _context.Orders.Where(c => c.Date.Date == DateTime.Now.Date).CountAsync(),
                ActiveOrders = await _context.Orders.Where(c => c.StatusId == 1).CountAsync(),
                OrdersTotalValue = await _context.Orders.SumAsync(c => c.PriceTotal),
                AverageOrderValue = await _context.Orders.AverageAsync(c => c.PriceTotal),
                OrderDisplayDto = new List<OrderDisplayDto>()
            };
            var db = await _context.Orders
                .Include(c => c.OrdersProducts)
                .ThenInclude(c => c.Product)
                .Include(c => c.Customer)
                .Include(c => c.PaymentType)
                .Include(c => c.Status)
                .OrderByDescending(c => c.Id).ToListAsync();
            foreach (var order in db)
                result.OrderDisplayDto.Add(new OrderDisplayDto(order));

            return Ok(result);
        }
    }
}
