﻿using System;
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
        private readonly AppDbContext _orderService;
        public OrderController(AppDbContext context)
        {
            _orderService = context;
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Order>> GetById(int id)
        {
            var service = new CrudService<Order>(_orderService);
            var order = await service.GetById(id);

            return Ok(await service.GetById(order.Id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Order>> GetAll()
        {
            var service = new CrudService<Order>(_orderService);
            return Ok(await service.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> Delete(int id)
        {
            var service = new CrudService<Order>(_orderService);
            var order = await service.GetById(id);

            order.IsActive = false;

            await service.Update(order);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Add([FromBody] Order order)
        {
            var service = new CrudService<Order>(_orderService);

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
            var service = new CrudService<Order>(_orderService);
            var oldOrder = await service.GetById(updatedOrder.Id);

            return Ok(await service.Update(oldOrder));
        }
    }
}
