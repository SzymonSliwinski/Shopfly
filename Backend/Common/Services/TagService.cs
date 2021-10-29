using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models.ShopModels;
using Microsoft.EntityFrameworkCore;

namespace Common.Services
{
    public class TagService
    {
        private readonly AppDbContext _context;
        public TagService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Tag> GetById(int id)
        {
            var result = await _context.Tags
                .AsQueryable()
                .SingleAsync(t => t.Id == id);

            return result;
        }

        public async Task<Tag> Delete(int id)
        {
            var tagDb = await GetById(id);
            await _context.SaveChangesAsync();

            return tagDb;
        }

        public async Task<Tag> Add(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<List<Tag>> GetAll()
        {
            return await _context.Tags
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<Tag> Update(Tag updatedTag)
        {
            var oldTag = await GetById(updatedTag.Id);
            oldTag.Name = updatedTag.Name;

            await _context.SaveChangesAsync();
            return oldTag;
        }
    }
}
