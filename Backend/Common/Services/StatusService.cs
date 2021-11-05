using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models.ShopModels;
using Microsoft.EntityFrameworkCore;

namespace Common.Services
{
    public class StatusService
    {
        private readonly AppDbContext _context;
        public StatusService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Status> GetById(int id)
        {
            var result = await _context.Statuses
                .AsQueryable()
                .SingleAsync(s => s.Id == id);

            return result;
        }

        public async Task<Status> Delete(int id)
        {
            var statusDb = await GetById(id);
            await _context.SaveChangesAsync();

            return statusDb;
        }

        public async Task<Status> Add(Status status)
        {
            await _context.Statuses.AddAsync(status);
            await _context.SaveChangesAsync();
            return status;
        }

        public async Task<List<Status>> GetAll()
        {
            return await _context.Statuses
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<Status> Update(Status updatedStatus)
        {
            var oldStatus = await GetById(updatedStatus.Id);
            oldStatus.Name = updatedStatus.Name;

            await _context.SaveChangesAsync();
            return oldStatus;
        }
    }
}
