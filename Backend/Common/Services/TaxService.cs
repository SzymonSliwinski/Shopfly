using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models.ShopModels;
using Microsoft.EntityFrameworkCore;

namespace Common.Services
{
    public class TaxService
    {
        private readonly AppDbContext _context;
        public TaxService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Tax> GetById(int id)
        {
            var result = await _context.Taxes
                .AsQueryable()
                .SingleAsync(t => t.Id == id);

            return result;
        }

        public async Task<Tax> Delete(int id)
        {
            var taxDb = await GetById(id);
            await _context.SaveChangesAsync();

            return taxDb;
        }

        public async Task<Tax> Add(Tax tax)
        {
            await _context.Taxes.AddAsync(tax);
            await _context.SaveChangesAsync();
            return tax;
        }

        public async Task<List<Tax>> GetAll()
        {
            return await _context.Taxes
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<Tax> Update(Tax updatedTax)
        {
            var oldTax = await GetById(updatedTax.Id);
            oldTax.Name = updatedTax.Name;
            oldTax.Interest = updatedTax.Interest;

            await _context.SaveChangesAsync();
            return oldTax;
        }
    }
}
