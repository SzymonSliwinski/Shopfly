using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models.ShopModels;
using Microsoft.EntityFrameworkCore;

namespace Common.Services
{
    public class ProductVariantService
    {
        private readonly AppDbContext _context;
        public ProductVariantService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductVariant> GetById(int id)
        {
            var result = await _context.ProductVariants
                .AsQueryable()
                .SingleAsync(pv => pv.Id == id);

            return result;
        }

        public async Task<ProductVariant> Delete(int id)
        {
            var productDb = await GetById(id);
            await _context.SaveChangesAsync();

            return productDb;
        }

        public async Task<ProductVariant> Add(ProductVariant productVariant)
        {
            await _context.ProductVariants.AddAsync(productVariant);
            await _context.SaveChangesAsync();
            return productVariant;
        }

        public async Task<List<ProductVariant>> GetAll()
        {
            return await _context.ProductVariants
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<ProductVariant> Update(ProductVariant updatedProductVariant)
        {
            var oldProductVariant = await GetById(updatedProductVariant.Id);
            oldProductVariant.ColorId = updatedProductVariant.ColorId;
            oldProductVariant.DimensionId = updatedProductVariant.DimensionId;
            oldProductVariant.Price = updatedProductVariant.Price;
            oldProductVariant.IsOnSale = updatedProductVariant.IsOnSale;
            oldProductVariant.SalePercentage = updatedProductVariant.SalePercentage;
            oldProductVariant.Quantity = updatedProductVariant.Quantity;
            oldProductVariant.ProductId = updatedProductVariant.ProductId;

            await _context.SaveChangesAsync();
            return oldProductVariant;
        }
    }
}
