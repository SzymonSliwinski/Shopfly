using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models.ShopModels;
using Microsoft.EntityFrameworkCore;

namespace Common.Services
{
    public class ProductColorService
    {
        private readonly AppDbContext _context;
        public ProductColorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductColor> GetById(int id)
        {
            var result = await _context.ProductColors
                .AsQueryable()
                .SingleAsync(pc => pc.Id == id);

            return result;
        }

        public async Task<ProductColor> Delete(int id)
        {
            var productColorDb = await GetById(id);
            await _context.SaveChangesAsync();

            return productColorDb;
        }

        public async Task<ProductColor> Add(ProductColor productColor)
        {
            productColor.HexValue = productColor.HexValue.Trim();
            await _context.ProductColors.AddAsync(productColor);
            await _context.SaveChangesAsync();
            return productColor;
        }

        public async Task<List<ProductColor>> GetAll()
        {
            return await _context.ProductColors
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<ProductColor> Update(ProductColor updatedProductColor)
        {
            var oldProductColor = await GetById(updatedProductColor.Id);
            oldProductColor.HexValue = updatedProductColor.HexValue.Trim();

            await _context.SaveChangesAsync();
            return oldProductColor;
        }
    }
}
