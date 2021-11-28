using Common.Dtos;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Services
{
    public class ManyToManyCrudService<T> where T : ManyToManyEntityBase
    {
        private AppDbContext _context;
        private readonly DbSet<T> _table;
        public ManyToManyCrudService(AppDbContext _context)
        {
            this._context = _context;
            _table = _context.Set<T>();
        }
        public async Task<T> GetByKey(int key1, int key2)
        {
            return await _table.FindAsync(key1, key2);
        }

        public async Task<T> GetById(object id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<T> Insert(T item)
        {
            await _table.AddAsync(item);
            _context.SaveChanges();
            return item;
        }

        public async Task Delete(int key1, int key2)
        {
            T existing = await GetByKey(key1, key2);
            _table.Remove(existing);
            _context.SaveChanges();

        }
    }
}
