using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Dtos;
using Common.Models.ShopModels;
using Microsoft.EntityFrameworkCore;

namespace Common.Services
{
    public class ProductsPaymentsService
    {
        private readonly AppDbContext _context;
        public ProductsPaymentsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductsPayments> FindOne(int productId, int paymentTypeId)
        {
            var result = await _context.ProductsPayments
                .AsQueryable()
                .SingleAsync(pp => pp.ProductId == productId && pp.PaymentTypeId == paymentTypeId);

            return result;
        }

        public async Task<ProductsPayments> Delete(int productId, int paymentTypeId)
        {
            var productsPaymentsDb = await FindOne(productId, paymentTypeId);
            _context.Remove(productsPaymentsDb);
            await _context.SaveChangesAsync();

            return productsPaymentsDb;
        }

        public async Task<ProductsPayments> Add(ProductsPayments productsPayments)
        {
            var newProductsPayments = new ProductsPayments()
            {
                ProductId = productsPayments.ProductId,
                PaymentTypeId = productsPayments.PaymentTypeId
            };

            await _context.AddAsync(newProductsPayments);
            await _context.SaveChangesAsync();

            return newProductsPayments;
        }

        public async Task<ProductsPayments> Update(UpdateModelDto<ProductsPayments> modelsDto)
        {
            await Delete(modelsDto.OldModel.ProductId, modelsDto.OldModel.PaymentTypeId);
            await Add(modelsDto.NewModel);
            return modelsDto.NewModel;
        }

        public async Task<List<ProductsPayments>> AddMany(List<ProductsPayments> productsPaymentsList)
        {
            foreach (var productsPayments in productsPaymentsList)
                await Add(productsPayments);

            return productsPaymentsList;
        }

        public async Task<List<ProductsPayments>> RemoveMany(List<ProductsPayments> productsPaymentsList)
        {
            foreach (var productsPayments in productsPaymentsList)
                await Delete(productsPayments.ProductId, productsPayments.PaymentTypeId);

            return productsPaymentsList;
        }
    }
}
