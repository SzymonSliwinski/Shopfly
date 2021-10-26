using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models.ShopModels;
using Microsoft.EntityFrameworkCore;

namespace Common.Services
{
    public class CarrierService
    {
        private readonly AppDbContext _context;
        public CarrierService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Carrier> GetById(int id)
        {
            var result = await _context.Carriers
                .AsQueryable()
                .SingleAsync(p => p.Id == id);

            return result;
        }

        public async Task<Carrier> Delete(int id)
        {
            var carrierDb = await GetById(id);
            carrierDb.IsActive = false;
            await _context.SaveChangesAsync();

            return carrierDb;
        }

        public async Task<Carrier> Add(Carrier carrier)
        {
            carrier.Name = carrier.Name.Trim();
            carrier.IsActive = true;
            await _context.Carriers.AddAsync(carrier);
            await _context.SaveChangesAsync();
            return carrier;
        }

        public async Task<List<Carrier>> GetAll()
        {
            return await _context.Carriers
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<Carrier> Update(Carrier updatedCarrier)
        {
            var oldCarrier = await GetById(updatedCarrier.Id);
            oldCarrier.Cost= updatedCarrier.Cost;
            oldCarrier.Name = updatedCarrier.Name.Trim();
            oldCarrier.Logo = updatedCarrier.Logo;
            oldCarrier.DeliveryDaysMinimum = updatedCarrier.DeliveryDaysMinimum;
            oldCarrier.DeliveryDaysMaximum = updatedCarrier.DeliveryDaysMaximum;

            await _context.SaveChangesAsync();
            return oldCarrier;
        }
    }
}
