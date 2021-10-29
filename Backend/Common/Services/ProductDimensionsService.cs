using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models.ShopModels;
using Microsoft.EntityFrameworkCore;

namespace Common.Services
{
    public class ProductDimensionsService
    {
        private readonly AppDbContext _context;
        public ProductDimensionsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDimensions> GetById(int id)
        {
            var result = await _context.ProductDimensions
                .AsQueryable()
                .SingleAsync(pd => pd.Id == id);

            return result;
        }

        public async Task<ProductDimensions> Delete(int id)
        {
            var productDimensionsDb = await GetById(id);
            await _context.SaveChangesAsync();

            return productDimensionsDb;
        }

        public async Task<ProductDimensions> Add(ProductDimensions productDimensions)
        {
            await _context.ProductDimensions.AddAsync(productDimensions);
            await _context.SaveChangesAsync();
            return productDimensions;
        }

        public async Task<List<ProductDimensions>> GetAll()
        {
            return await _context.ProductDimensions
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<ProductDimensions> Update(ProductDimensions updatedProductDimensions)
        {
            var oldProductDimensions = await GetById(updatedProductDimensions.Id);
            oldProductDimensions.Width = updatedProductDimensions.Width;
            oldProductDimensions.Height = updatedProductDimensions.Height;
            oldProductDimensions.Weight = updatedProductDimensions.Weight;

            await _context.SaveChangesAsync();
            return oldProductDimensions;
        }
    }
}
