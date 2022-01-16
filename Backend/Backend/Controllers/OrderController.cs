using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopModels;
using Common.Services;

namespace ShopWebApi.Controllers
{
    [Route("shop/[controller]")]
    //[TokenAuthenticationFilter]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _orderService;
        public OrderController(AppDbContext context)
        {
            _orderService = context;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Order>> GetAll()
        {
            var service = new CrudService<Order>(_orderService);
            return Ok(await service.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Add([FromBody] Order order)
        {
            var service = new CrudService<Order>(_orderService);

            order.Date = DateTime.Now.ToLocalTime();
            order.StatusId = 1;
            //  order.AdditionalDescription = order.AdditionalDescription.Trim();
            order.IsActive = true;

            order.DeliveryAddressStreet = order.DeliveryAddressStreet.Trim();
            order.DeliveryAddressPostal = order.DeliveryAddressPostal.Trim();
            order.DeliveryAddressCity = order.DeliveryAddressCity.Trim();
            order.DeliveryAddressCountry = order.DeliveryAddressCountry.Trim();

            if (order.BillingAddressStreet != null)
                order.BillingAddressStreet = order.BillingAddressStreet.Trim();

            if (order.BillingAddressPostal != null)
                order.BillingAddressPostal = order.BillingAddressPostal.Trim();
            if (order.BillingAddressCity != null)
                order.BillingAddressStreet = order.BillingAddressCity.Trim();

            if (order.BillingAddressCountry != null)
                order.BillingAddressCountry = order.BillingAddressCountry.Trim();
            if (order.Nip != null)
                order.Nip = order.Nip.Trim();
            if (order.CompanyName != null)
                order.CompanyName = order.CompanyName.Trim();

            order.CustomerPhoneNumber = order.CustomerPhoneNumber.Trim();
            order.CustomerEmail = order.CustomerEmail.Trim();

            return Ok(await service.Insert(order));
        }

    }
}
