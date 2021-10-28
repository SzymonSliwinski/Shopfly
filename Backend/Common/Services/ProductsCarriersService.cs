using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models.ShopModels;
using Microsoft.EntityFrameworkCore;

namespace Common.Services
{
    public class ProductsCarriersService
    {
        private readonly AppDbContext _context;
        public ProductsCarriersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductsCarriers> FindOne(int productId, int carrierId)
        {
            var result = await _context.ProductsCarriers
                .AsQueryable()
                .SingleAsync(pc => pc.ProductId == productId && pc.CarrierId == carrierId);

            return result;
        }

        public async Task<ProductsCarriers> Delete(int productId, int carrierId)
        {
            var productsCarriersDb = await FindOne(productId, carrierId);
            _context.Remove(productsCarriersDb);
            await _context.SaveChangesAsync();

            return productsCarriersDb;
        }

        public async Task<ProductsCarriers> Add(ProductsCarriers productsCarriers)
        {
            var newProductsCarriers = new ProductsCarriers()
            {
                ProductId = productsCarriers.ProductId,
                CarrierId = productsCarriers.CarrierId
            };

            await _context.AddAsync(newProductsCarriers);
            await _context.SaveChangesAsync();

            return newProductsCarriers;
        }

        public async Task<ProductsCarriers> Update(ProductsCarriers oldProductsCarriers, ProductsCarriers newProductsCarriers)
        {
            await Delete(oldProductsCarriers.ProductId, oldProductsCarriers.CarrierId);
            await Add(newProductsCarriers);
            return newProductsCarriers;
        }

        public async Task<List<ProductsCarriers>> AddMany(List<ProductsCarriers> productsCarriersList)
        {
            foreach (var productsCarriers in productsCarriersList)
                await Add(productsCarriers);

            return productsCarriersList;
        }

        public async Task<List<ProductsCarriers>> RemoveMany(List<ProductsCarriers> productsCarriersList)
        {
            foreach (var productsCarriers in productsCarriersList)
                await Delete(productsCarriers.ProductId, productsCarriers.CarrierId);

            return productsCarriersList;
        }
    }
}
