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
    [Route("shop/home-lists")]
    [ApiController]
    public class ShopListsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private CrudService<HomeList> _service;
        public ShopListsController(AppDbContext context)
        {
            _context = context;
            _service = new CrudService<HomeList>(_context);
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<HomeList>>> GetAll()
        {

            return Ok(
                await _context.HomeLists
                .Include(c => c.HomeProductsLists)
                .ThenInclude(c => c.Product)
                .ThenInclude(c => c.Ratings)
                .ThenInclude(c => c.Product)
                .ThenInclude(c => c.ProductsVariants)
                .ThenInclude(c => c.ProductsVariantsPhotos)
                .ThenInclude(c => c.Photo)
                .ToListAsync()
                );
        }
    }
}
