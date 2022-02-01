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
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        private CrudService<Product> _service;
        private ShopWebApi.Services.CategoryService _catService;
        private FvService _fvService;
        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _service = new CrudService<Product>(_context);
            _catService = new ShopWebApi.Services.CategoryService();
            _fvService = new FvService(context, env);
        }

        [HttpPost("by-filter/page/{page}")]
        public async System.Threading.Tasks.Task<ActionResult<List<Product>>> GetAllRelatedProducts([FromBody] FilterDto filterDto, int page)
        {
            var relatedCategories = new List<int>();
            var shopConfig = await _context.ShopSettings.SingleAsync();
            var db = await _context.Categories
                .Include(c => c.ChildrensCategories)
                .Where(c => c.IsActive)
                .ToListAsync();

            var categoryTree = db.Where(c => c.Name == filterDto.Category).Single();
            _catService.TraverseCategories(categoryTree, relatedCategories);
            var query = _context.Products.AsQueryable();
            query = query.Where(p => p.IsVisible && relatedCategories.Any(rc => rc == p.CategoryId));
            if (filterDto.Min != null && filterDto.Max != null)
                query = query.Where(p => p.BruttoPrice >= filterDto.Min && p.BruttoPrice <= filterDto.Max);

            switch (filterDto.SortBy)
            {
                case 1: query = query.OrderBy(c => c.BruttoPrice); break;
                case 2: query = query.OrderByDescending(c => c.BruttoPrice); break;
                case 3: query = query.OrderBy(c => c.Name); break;
                case 4: query = query.OrderByDescending(c => c.Name); break;
            }

            query = query.Skip(shopConfig.ProductsPerPage * (page - 1))
                 .Take(shopConfig.ProductsPerPage)
                 .Include(c => c.Ratings);

            return Ok(await query.ToListAsync());
        }

        [HttpPost("by-filter")]
        public async System.Threading.Tasks.Task<ActionResult<int>> GetAllRelatedProductsCount([FromBody] FilterDto filterDto)
        {
            var relatedCategories = new List<int>();
            var db = await _context.Categories
                .Include(c => c.ChildrensCategories)
                .Where(c => c.IsActive)
                .ToListAsync();
            var categoryTree = db.Where(c => c.Name == filterDto.Category).Single();
            _catService.TraverseCategories(categoryTree, relatedCategories);
            var query = _context.Products.AsQueryable();
            query = query.Where(p => relatedCategories.Any(rc => rc == p.CategoryId));
            if (filterDto.Min != null && filterDto.Max != null)
                query = query.Where(p => p.BruttoPrice >= filterDto.Min && p.BruttoPrice <= filterDto.Max);
            return Ok(await query.CountAsync());
        }

        [HttpGet("photo/{productId}")]
        public async System.Threading.Tasks.Task<ActionResult<Photo>> GetPhotoForProduct(int productId)
        {
            var product = await _context.Products
                .AsQueryable()
                .Where(c => c.Id == productId)
                .Include(p => p.Category)
                .Include(c => c.ProductsVariants)
                .ThenInclude(c => c.ProductsVariantsPhotos)
                .ThenInclude(c => c.Photo)
                .SingleAsync();

            return File(product.ProductsVariants.First().ProductsVariantsPhotos.First().Photo.Bytes, "application/png", "");
        }

        [HttpGet("details/{productId}")]
        public async System.Threading.Tasks.Task<ActionResult<Photo>> GetProductDetails(int productId)
        {
            return Ok(await _context.Products
                .AsQueryable()
                .Where(c => c.Id == productId)
                .Include(p => p.Category)
                .Include(p => p.Ratings)
                .ThenInclude(c => c.Customer)
                 .Include(p => p.Comments)
                  .ThenInclude(c => c.Customer)
                .SingleAsync());
        }



        [HttpGet("fv/{orderId}")]
        public async System.Threading.Tasks.Task<ActionResult<byte[]>> GetFvForOrder(int orderId)
        {
            return File(await _fvService.GetFVForOrder(orderId), "application/json", "FV.pdf");
        }
    }

    public class FilterDto
    {
        public int? Min { get; set; }
        public int? Max { get; set; }
        public string Category { get; set; }
        public short? SortBy { get; set; }
    }

}
