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

        public T GetById(int id)
        {
            return _table.Find(id);
        }
        public async Task<T> Insert(T item)
        {
            await _table.AddAsync(item);
            _context.SaveChanges();
            return item;
        }
    }
}
