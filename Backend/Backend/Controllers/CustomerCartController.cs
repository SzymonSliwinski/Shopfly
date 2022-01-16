
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
            payload.Quantity = 1;
            await _service.Insert(payload);
        }
    }
}
