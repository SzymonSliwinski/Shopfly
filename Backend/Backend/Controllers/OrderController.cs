using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopModels;
using Common.Services;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopPanelWebApi.Dtos;
using Microsoft.AspNetCore.Hosting;
using ShopWebApi.Services;

namespace ShopWebApi.Controllers
{
    [Route("shop/[controller]")]
    //[TokenAuthenticationFilter]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;
        private FvService _fvService;
        private MailService _mailService;

        public OrderController(AppDbContext context, IWebHostEnvironment env)
        {
            _fvService = new FvService(context, env);
            _context = context;
            _mailService = new MailService();
        }

        [HttpGet("get-all")]
        public async System.Threading.Tasks.Task<ActionResult<Order>> GetAll()
        {
            var service = new CrudService<Order>(_context);
            return Ok(await service.GetAll());
        }

        [HttpGet("get-user-orders/{userId}")]
        public async System.Threading.Tasks.Task<ActionResult<List<OrderDisplayDto>>> GetUserOrders(int userId)
        {
            var result = new List<OrderDisplayDto>();

            var db = await _context.Orders
                .Include(c => c.OrdersProducts)
                .ThenInclude(c => c.Product)
                .Include(c => c.Customer)
                .Include(c => c.PaymentType)
                .Include(c => c.Status)
                .Where(c => c.CustomerId == userId)
                .OrderByDescending(c => c.Id).ToListAsync();

            foreach (var order in db)
                result.Add(new OrderDisplayDto(order));

            return Ok(result);

        }

        [HttpGet("get-all-for-order/{orderId}")]
        public async System.Threading.Tasks.Task<ActionResult<List<ProductDisplayDto>>> GetProductsForOrder(int orderId)
        {
            var results = new List<ProductDisplayDto>();
            var ordersProducts = await _context.OrdersProducts
                .AsQueryable()
                .Include(c => c.Product)
                .ThenInclude(c => c.Category)
                .Where(c => c.OrderId == orderId).ToListAsync();
            foreach (var orderProduct in ordersProducts)
            {
                results.Add(new ProductDisplayDto(orderProduct.Product));
            }

            return Ok(results);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult<Order>> Add([FromBody] Order order)
        {
            var service = new CrudService<Order>(_context);

            order.Date = DateTime.Now.ToLocalTime();
            order.StatusId = 1;
            foreach (var orderProduct in order.OrdersProducts)
            {
                var product = await _context.Products.Where(c => c.Id == orderProduct.ProductId).SingleAsync();
                product.Stock = product.Stock - (int)orderProduct.ProductQuantity;
                orderProduct.Order = order;
                await _context.SaveChangesAsync();
            }

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
            await service.Insert(order);
            await _context.SaveChangesAsync();
            _mailService.SendEmail(order.CustomerEmail, "New order from shopfly", "Thank you for your purchase", await _fvService.GetFVForOrder(order.Id));

            return Ok(order);
        }

        [HttpGet("fv/{orderId}")]
        public async System.Threading.Tasks.Task<ActionResult<byte[]>> GetFvForOrder(int orderId)
        {
            return File(await _fvService.GetFVForOrder(orderId), "application/json", "FV.pdf");
        }
    }
}
