using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models.ShopModels;
using Microsoft.EntityFrameworkCore;

namespace Common.Services
{
    public class PaymentTypeService
    {
        private readonly AppDbContext _context;
        public PaymentTypeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PaymentType> GetById(int id)
        {
            var result = await _context.PaymentTypes
                .AsQueryable()
                .SingleAsync(pt => pt.Id == id);

            return result;
        }

        public async Task<PaymentType> Delete(int id)
        {
            var productDb = await GetById(id);
            productDb.IsActive = false;
            await _context.SaveChangesAsync();

            return productDb;
        }

        public async Task<PaymentType> Add(PaymentType paymentType)
        {
            paymentType.Name = paymentType.Name.Trim();
            paymentType.Icon = paymentType.Icon.Trim();
            paymentType.IsActive = true;
            await _context.PaymentTypes.AddAsync(paymentType);
            await _context.SaveChangesAsync();
            return paymentType;
        }

        public async Task<List<PaymentType>> GetAll()
        {
            return await _context.PaymentTypes
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<PaymentType> Update(PaymentType updatedPaymentType)
        {
            var oldPaymentType = await GetById(updatedPaymentType.Id);
            oldPaymentType.Name = updatedPaymentType.Name.Trim();
            oldPaymentType.Icon = updatedPaymentType.Icon.Trim();

            await _context.SaveChangesAsync();
            return oldPaymentType;
        }

    }
}
