
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopPanelModels;
using Common.Services;
using Common.Utilieties;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Common.Dtos;
using Common.Models.ShopModels;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop/customer-cart")]
    [ApiController]
    public class CustomerCartcontroller : ControllerBase
    {
        private readonly AppDbContext _context;
        private ManyToManyCrudService<CustomerCart> _service;
        public CustomerCartcontroller(AppDbContext context)
        {
            _context = context;
            _service = new ManyToManyCrudService<CustomerCart>(_context);
        }

        [HttpGet("get-all/for-user/{userId}")]
        public async Task<ActionResult<List<CustomerCart>>> GetAll(int userId)
        {

            return Ok(await _context.CustomersCarts
                .Where(c => c.CustomerId == userId)
                .Include(c => c.Product)
                .ThenInclude(c => c.ProductsVariants)
                .ThenInclude(c => c.ProductsVariantsPhotos)
                .ThenInclude(c => c.Photo)
                .ToListAsync()
                );
        }

        [HttpPost]
        public async Task Add([FromBody] CustomerCart payload)
        {
            var db = await _context.CustomersCarts
                .Where(c => c.ProductId == payload.ProductId && c.CustomerId == payload.CustomerId)
                .SingleOrDefaultAsync();
            if (db == null)
            {
                payload.Quantity = 1;
                await _service.Insert(payload);
            }
            else
            {
                db.Quantity++;
            }
            await _context.SaveChangesAsync();
        }

        [HttpDelete("clear-user-cart/{userId}")]
        public async Task ClearUserCart(int userId)
        {
            var db = await _context.CustomersCarts
                .Where(c => c.CustomerId == userId).ToListAsync();
            _context.RemoveRange(db);
            await _context.SaveChangesAsync();
        }

        [HttpDelete("remove/{productId}/{userId}")]
        public async Task RemoveProduct(int userId, int productId)
        {
            var db = await _context.CustomersCarts
                .Where(c => c.CustomerId == userId && c.ProductId == productId)
                .SingleAsync();
            _context.Remove(db);
            await _context.SaveChangesAsync();
        }
    }
}
