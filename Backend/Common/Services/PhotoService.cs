using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models.ShopModels;
using Microsoft.EntityFrameworkCore;

namespace Common.Services
{
    public class PhotoService
    {
        private readonly AppDbContext _context;
        public PhotoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Photo> GetById(int id)
        {
            var result = await _context.Photos
                .AsQueryable()
                .SingleAsync(p => p.Id == id);

            return result;
        }

        public async Task<Photo> Delete(int id)
        {
            var productDb = await GetById(id);
            await _context.SaveChangesAsync();

            return productDb;
        }

        public async Task<Photo> Add(Photo photo)
        {
            photo.Path = photo.Path.Trim();
            await _context.Photos.AddAsync(photo);
            await _context.SaveChangesAsync();
            return photo;
        }

        public async Task<List<Photo>> GetAll()
        {
            return await _context.Photos
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<Photo> Update(Photo updatedPhoto)
        {
            var oldPhoto = await GetById(updatedPhoto.Id);
            oldPhoto.IsCover = updatedPhoto.IsCover;
            oldPhoto.Path = updatedPhoto.Path.Trim();

            await _context.SaveChangesAsync();
            return oldPhoto;
        }
    }
}
