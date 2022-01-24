using System.Collections;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopModels;
using Common.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ShopWebApi.Controllers
{
    [Route("shop/[controller]")]
    //[TokenAuthenticationFilter]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        private CrudService<Category> _service;
        public CategoryController(AppDbContext context)
        {
            _context = context;
            _service = new CrudService<Category>(_context);
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<Category>>> GetAll()
        {
            var results = await _context.Categories
                .AsQueryable()
                .OrderBy(c => c.Position)
                .Include(c => c.ChildrensCategories)
                .Where(c => c.IsActive)
                .ToListAsync();
            return Ok(results.Where(c => c.IsRoot).ToList());
        }
    }
}
