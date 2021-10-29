using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models.ShopModels;
using Microsoft.EntityFrameworkCore;

namespace Common.Services
{
    public class CategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Category> GetById(int id)
        {
            var result = await _context.Categories
                .AsQueryable()
                .SingleAsync(c => c.Id == id);

            return result;
        }

        public async Task<Category> Delete(int id)
        {
            var categoryDb = await GetById(id);
            await _context.SaveChangesAsync();

            return categoryDb;
        }

        public async Task<Category> Add(Category category)
        {
            category.Name = category.Name.Trim();
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<Category> Update(Category updatedCategory)
        {
            var oldCategory = await GetById(updatedCategory.Id);
            oldCategory.Name = updatedCategory.Name.Trim();
            oldCategory.IsRoot = updatedCategory.IsRoot;
            oldCategory.ParentCategoryId = updatedCategory.ParentCategoryId;
            oldCategory.Position = updatedCategory.Position;
            
            await _context.SaveChangesAsync();
            return oldCategory;
        }
    }
}
