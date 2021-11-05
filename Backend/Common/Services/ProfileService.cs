using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models.ShopPanelModels;
using Microsoft.EntityFrameworkCore;

namespace Common.Services
{
    public class ProfileService
    {
        private readonly AppDbContext _context;
        public ProfileService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Profile> GetById(int id)
        {
            var result = await _context.Profiles
                .AsQueryable()
                .SingleAsync(p => p.Id == id);

            return result;
        }

        public async Task<Profile> Delete(int id)
        {
            var profileDb = await GetById(id);
            await _context.SaveChangesAsync();

            return profileDb;
        }

        public async Task<Profile> Add(Profile profile)
        {
            profile.Name = profile.Name.Trim();
            await _context.Profiles.AddAsync(profile);
            await _context.SaveChangesAsync();
            return profile;
        }

        public async Task<List<Profile>> GetAll()
        {
            return await _context.Profiles
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<Profile> Update(Profile updatedProfile)
        {
            var oldProfile = await GetById(updatedProfile.Id);
            oldProfile.Name = updatedProfile.Name;

            await _context.SaveChangesAsync();
            return oldProfile;
        }
    }
}
