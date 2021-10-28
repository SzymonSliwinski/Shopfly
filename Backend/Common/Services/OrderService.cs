using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models.ShopModels;
using Microsoft.EntityFrameworkCore;
using DateTime = System.DateTime;

namespace Common.Services
{
    public class OrderService
    {
        private readonly AppDbContext _context;
        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetById(int id)
        {
            var result = await _context.Orders
                .AsQueryable()
                .SingleAsync(o => o.Id == id);

            return result;
        }

        public async Task<Order> Delete(int id)
        {
            var orderDb = await GetById(id);
            orderDb.IsActive = false;
            await _context.SaveChangesAsync();

            return orderDb;
        }

        public async Task<Order> Add(Order order)
        {
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

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.Orders
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<Order> Update(Order updatedOrder)
        {
            var oldOrder = await GetById(updatedOrder.Id);
            oldOrder.PaymentTypeId = updatedOrder.PaymentTypeId;
            oldOrder.StatusId = updatedOrder.StatusId;
            oldOrder.CarrierId = updatedOrder.CarrierId;
            oldOrder.PriceTotal = updatedOrder.PriceTotal;
            oldOrder.AdditionalDescription = updatedOrder.AdditionalDescription;
            oldOrder.AdditionalDescription = updatedOrder.AdditionalDescription;
            
            oldOrder.DeliveryAddressStreet = updatedOrder.DeliveryAddressStreet;
            oldOrder.DeliveryAddressPostal = updatedOrder.DeliveryAddressPostal;
            oldOrder.DeliveryAddressCity = updatedOrder.DeliveryAddressCity;
            oldOrder.DeliveryAddressCountry = updatedOrder.DeliveryAddressCountry;

            oldOrder.BillingAddressStreet = updatedOrder.BillingAddressStreet;
            oldOrder.BillingAddressPostal = updatedOrder.BillingAddressPostal;
            oldOrder.BillingAddressCity = updatedOrder.BillingAddressCity;
            oldOrder.BillingAddressCountry = updatedOrder.BillingAddressCountry;
            
            oldOrder.Nip = updatedOrder.Nip;
            oldOrder.CompanyName = updatedOrder.CompanyName;
            oldOrder.CustomerPhoneNumber = updatedOrder.CustomerPhoneNumber;
            oldOrder.CustomerEmail = updatedOrder.CustomerEmail;

            await _context.SaveChangesAsync();
            return oldOrder;
        }
    }
}
