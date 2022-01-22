
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
    [Route("shop/customer-favorites")]
    [ApiController]
    public class CustomerFavoritesProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private ManyToManyCrudService<CustomerFavouritesProducts> _service;
        public CustomerFavoritesProductsController(AppDbContext context)
        {
            _context = context;
            _service = new ManyToManyCrudService<CustomerFavouritesProducts>(_context);
        }

        [HttpGet("get-all/for-user/{userId}")]
        public async Task<ActionResult<List<CustomerFavouritesProducts>>> GetAll(int userId)
        {

            return Ok(await _context.CustomerFavouritesProducts
                .Where(c => c.CustomerId == userId)
                .Include(c => c.Product)
                .ThenInclude(c => c.ProductsVariants)
                .ThenInclude(c => c.ProductsVariantsPhotos)
                .ThenInclude(c => c.Photo)
                .ToListAsync()
                );
        }

        [HttpPost]
        public async Task Add([FromBody] CustomerFavouritesProducts payload)
        {
            await _service.Insert(payload);
        }
    }
}
