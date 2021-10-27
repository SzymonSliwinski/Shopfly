using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models.ShopPanelModels;
using Microsoft.EntityFrameworkCore;

namespace Common.Services
{
    public class PrivilegeService
    {
        private readonly AppDbContext _context;
        public PrivilegeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Privilege> GetById(int id)
        {
            var result = await _context.Privileges
                .AsQueryable()
                .SingleAsync(p => p.Id == id);

            return result;
        }

        public async Task<Privilege> Delete(int id)
        {
            var privilegeDb = await GetById(id);
            await _context.SaveChangesAsync();

            return privilegeDb;
        }

        public async Task<Privilege> Add(Privilege privilege)
        {
            privilege.Name = privilege.Name.Trim();
            await _context.Privileges.AddAsync(privilege);
            await _context.SaveChangesAsync();
            return privilege;
        }

        public async Task<List<Privilege>> GetAll()
        {
            return await _context.Privileges
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<Privilege> Update(Privilege updatedPrivilege)
        {
            var oldPrivilege = await GetById(updatedPrivilege.Id);
            oldPrivilege.Name = updatedPrivilege.Name;

            await _context.SaveChangesAsync();
            return oldPrivilege;
        }
    }
}
