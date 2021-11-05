using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.EntityFrameworkCore;

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

            for(var day = dateFrom.Date; day.Date <= dateTo.Date; day = day.AddDays(1)) // wypełnia cały słownik zakresem dat
                result.Add(day.Date, 0);

            foreach(var orderFromDays in ordersFromDays)
                result[orderFromDays.Date]++;

            return result;
        }
    }
}
