using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Services
{
    public class CrudService<T> where T : EntityBase
    {
        private AppDbContext _context;
        private readonly DbSet<T> _table;
        public CrudService(AppDbContext _context)
        {
            this._context = _context;
            _table = _context.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await _table.FindAsync(id);
        }
        public async Task<T> Insert(T item)
        {
            await _table.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<T> Update(T item)
        {
            _table.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task Delete(object id)
        {
            T existing = await GetById(id);
            _table.Remove(existing);
            await _context.SaveChangesAsync();
        }
    }
}
