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
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Http;

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
            return Ok(await _context.Products
                .AsQueryable()
                .Where(c => c.IsActive)
                .ToListAsync());
        }

        [HttpGet("get-all-as-dtos")]
        public async Task<ActionResult<List<ProductDisplayDto>>> GetAllAsDtos()
        {
            var results = new List<ProductDisplayDto>();
            var products = await _context.Products
                .AsQueryable()
                .Include(p => p.Category)
                .Include(c => c.ProductsVariants)
                .ThenInclude(c => c.ProductsVariantsPhotos)
                .ThenInclude(c => c.Photo)
                .ToListAsync();

            foreach (var product in products)
                results.Add(new ProductDisplayDto(product));

            return Ok(results);
        }

        [HttpGet("photo/{productId}")]
        public async Task<ActionResult<Photo>> GetPhotoForProduct(int productId)
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
            product.ProductsVariants = new List<ProductVariant>();
            product.ProductsVariants.Add(new ProductVariant()
            {
                Price = product.NettoPrice,
                Quantity = product.Stock,
            });
            return Ok(await service.Insert(product));
        }

        [HttpPost("photo")]
        public async Task AddPhoto(IFormFile file)
        {
            var product = await _context.Products.Include(c => c.ProductsVariants).OrderByDescending(c => c.Id).FirstOrDefaultAsync();
            var productVariantPhotos = new List<ProductsVariantsPhotos>();
            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    var bytes = ms.ToArray();

                    var photo = new Photo()
                    {
                        IsCover = true,
                        Bytes = bytes
                    };
                    await _context.Photos.AddAsync(photo);
                    await _context.SaveChangesAsync();

                    productVariantPhotos.Add(new ProductsVariantsPhotos()
                    {
                        ProductVariantId = product.ProductsVariants.First().Id,
                        PhotoId = photo.Id
                    });
                }
                product.ProductsVariants.First().ProductsVariantsPhotos = productVariantPhotos;
                await _context.SaveChangesAsync();
            }
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
