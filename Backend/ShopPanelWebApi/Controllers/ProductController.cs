using System;
using Common;
using Common.Models.ShopModels;
using Common.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using ShopPanelWebApi.Dtos;
using Microsoft.EntityFrameworkCore;
using ShopPanelWebApi.Filters;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    [TokenAuthenticationFilter]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var service = new CrudService<Product>(_context);
            var product = await service.GetById(id);

            return Ok(await service.GetById(product.Id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Product>> GetAll()
        {
            var service = new CrudService<Product>(_context);
            return Ok(await service.GetAll());
        }

        [HttpGet("get-all-as-dtos")]
        public async Task<ActionResult<List<ProductDisplayDto>>> GetAllAsDtos()
        {
            var results = new List<ProductDisplayDto>();
            var products = await _context.Products
                .AsQueryable()
                .Include(p => p.Category)
                .ToListAsync();

            foreach (var product in products)
                results.Add(new ProductDisplayDto(product));
            return Ok(results);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            var service = new CrudService<Product>(_context);
            var product = await service.GetById(id);

            product.IsActive = false;

            await service.Update(product);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Add([FromBody] Product product)
        {
            var service = new CrudService<Product>(_context);

            product.Name = product.Name.Trim();
            product.IsActive = true;
            product.CreateDate = DateTime.Now.ToLocalTime();
            product.UpdateDate = DateTime.Now.ToLocalTime();
            product.CategoryId = 1;
            product.ProductsVariants = new List<ProductVariant>();
            product.ProductsVariants.Add(new ProductVariant());
            // to do with photo
            return Ok(await service.Insert(product));
        }

        [HttpPatch]
        public async Task<ActionResult<Product>> Update([FromBody] Product updatedProduct)
        {
            var service = new CrudService<Product>(_context);
            var oldProduct = await service.GetById(updatedProduct.Id);

            oldProduct.CategoryId = updatedProduct.CategoryId;
            oldProduct.Name = updatedProduct.Name.Trim();
            oldProduct.TaxId = updatedProduct.TaxId;
            oldProduct.IsLowStock = updatedProduct.IsLowStock;
            oldProduct.AdditionalShippingCost = updatedProduct.AdditionalShippingCost;
            oldProduct.NettoPrice = updatedProduct.NettoPrice;
            oldProduct.BruttoPrice = updatedProduct.BruttoPrice;
            oldProduct.IsVisible = updatedProduct.IsVisible;
            oldProduct.Description = updatedProduct.Description;
            oldProduct.UpdateDate = DateTime.Now.ToLocalTime();

            return Ok(await service.Update(oldProduct));
        }
    }
}
