using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopPanelModels;
using Common.Services;
using ShopWebApi.Services;
using Common.Utilieties;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Common.Dtos;
using Common.Models.ShopModels;
using System.Collections;
namespace ShopPanelWebApi.Controllers
{
    [Route("shop/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        private CrudService<Product> _service;
        private ShopWebApi.Services.CategoryService _catService;
        public ProductController(AppDbContext context)
        {
            _context = context;
            _service = new CrudService<Product>(_context);
            _catService = new ShopWebApi.Services.CategoryService();
        }

        [HttpGet("get-related-with/{category}")]
        public async System.Threading.Tasks.Task<ActionResult<List<Product>>> GetAllRelatedProducts(string category)
        {
            var relatedCategories = new List<int>();
            var db = await _context.Categories
                .Include(c => c.ChildrensCategories)
                .Where(c => c.IsActive)
                .ToListAsync();
            var categoryTree = db.Where(c => c.Name == category).Single();
            var categoriesQueue = new System.Collections.Generic.Queue<Category>();
            _catService.TraverseCategories(categoryTree, relatedCategories);
            var results = await _context.Products.Where(p => relatedCategories.Any(rc => rc == p.CategoryId)).ToListAsync();
            return Ok(results);
        }
    }
}
