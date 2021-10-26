using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models.ShopModels;
using Microsoft.EntityFrameworkCore;

namespace Common.Services
{
    public class RatingService
    {
        private readonly AppDbContext _context;
        public RatingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Rating> GetById(int id)
        {
            var result = await _context.Ratings
                .AsQueryable()
                .SingleAsync(r => r.Id == id);

            return result;
        }

        public async Task<Rating> Delete(int id)
        {
            var productDb = await GetById(id);
            await _context.SaveChangesAsync();

            return productDb;
        }

        public async Task<Rating> Add(Rating rating)
        {
            await _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync();
            return rating;
        }

        public async Task<List<Rating>> GetAll()
        {
            return await _context.Ratings
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<Rating> Update(Rating updatedRating)
        {
            var oldRating = await GetById(updatedRating.Id);
            oldRating.Rate = updatedRating.Rate;

            await _context.SaveChangesAsync();
            return oldRating;
        }
    }
}
