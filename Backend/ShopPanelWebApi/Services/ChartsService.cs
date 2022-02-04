using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopModels;
using Microsoft.EntityFrameworkCore;
using DateTime = System.DateTime;

namespace ShopPanelWebApi.Services
{
    public class ChartsService
    {
        private readonly AppDbContext _context;

        public ChartsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<DateTime, int>> GetOrdersChartDataFromDays(DateTime dateFrom, DateTime dateTo)
        {
            var ordersFromDays = await _context.Orders
                .AsQueryable()
                .Where(c => c.Date >= dateFrom.ToLocalTime() && c.Date <= dateTo.ToLocalTime())
                .ToListAsync();
            var result = new Dictionary<DateTime, int>();

            for (var day = dateFrom.Date;
                day.Date <= dateTo.Date;
                day = day.AddDays(1)) // wypełnia cały słownik zakresem dat
                result.Add(day.Date, 0);

            foreach (var orderFromDays in ordersFromDays)
                result[orderFromDays.Date.Date]++;

            return result;
        }

        public async Task<Dictionary<string, int>> GetCarriersChartDataFromDays(DateTime dateFrom, DateTime dateTo)
        {
            var ordersFromDaysList = await _context.Orders // list of all orders within a certain time range
                .AsQueryable()
                .Include(o => o.Carrier)
                .Where(o => o.Date >= dateFrom.ToLocalTime() && o.Date <= dateTo.ToLocalTime())
                .ToListAsync();

            var carrierDaysDictionary = new Dictionary<string, int>(); // carrier name, number of appearances

            foreach (var order in ordersFromDaysList)
                if (carrierDaysDictionary.ContainsKey(order.Carrier.Name))
                    carrierDaysDictionary[order.Carrier.Name]++;
                else
                    carrierDaysDictionary.Add(order.Carrier.Name, 1);

            return carrierDaysDictionary;
        }

        public async Task<Dictionary<string, int>> GetPaymentTypesChartDataFromDays(DateTime dateFrom, DateTime dateTo)
        {
            var ordersFromDaysList = await _context.Orders
                .AsQueryable()
                .Include(o => o.PaymentType)
                .Where(o => o.Date >= dateFrom.ToLocalTime() && o.Date <= dateTo.ToLocalTime())
                .ToListAsync();

            var paymentsDaysDictionary = new Dictionary<string, int>(); // payment type name, number of appearances

            foreach (var order in ordersFromDaysList)
                if (paymentsDaysDictionary.ContainsKey(order.PaymentType.Name))
                    paymentsDaysDictionary[order.PaymentType.Name]++;
                else
                    paymentsDaysDictionary.Add(order.PaymentType.Name, 1);

            return paymentsDaysDictionary;
        }

        public async Task<Dictionary<DateTime, int>> GetNewUserChartDataFromDays(DateTime dateFrom, DateTime dateTo)
        {
            var newUsersFromDaysList = await _context.Customers
                .AsQueryable()
                .Where(c => c.CreateDate >= dateFrom.ToLocalTime() && c.CreateDate <= dateTo.ToLocalTime())
                .ToListAsync();

            var newUserDaysDictionary = new Dictionary<DateTime, int>(); // date, number of new users

            for (var day = dateFrom.Date; day.Date <= dateTo.Date; day = day.AddDays(1))
                newUserDaysDictionary.Add(day.Date, 0);

            foreach (var customer in newUsersFromDaysList)
                newUserDaysDictionary[customer.CreateDate.Date]++;

            return newUserDaysDictionary;
        }

        public async Task<Dictionary<DateTime, int>> GetCompleteOrderChartDataFromDays(DateTime dateFrom, DateTime dateTo)
        {
            var completeOrdersFromDaysList = await _context.Orders
                .AsQueryable()
                .Where(o => o.CompleteDate >= dateFrom.ToLocalTime() && o.CompleteDate <= dateTo.ToLocalTime())
                .ToListAsync();

            var completeOrdersDaysDictionary = new Dictionary<DateTime, int>(); // date, number of completed orders

            for (var day = dateFrom.Date; day.Date <= dateTo.Date; day = day.AddDays(1))
                completeOrdersDaysDictionary.Add(day.Date, 0);

            foreach (var order in completeOrdersFromDaysList)
                completeOrdersDaysDictionary[order.CompleteDate.Date]++;

            return completeOrdersDaysDictionary;
        }
    }
}
