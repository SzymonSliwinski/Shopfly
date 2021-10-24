using Common.Models.ShopModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Services
{
    public class ProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetById(int id)
        {
            var result = await _context.Products
                .AsQueryable()
                .SingleAsync(p => p.Id == id);

            return result;
        }

        public async Task<Product> Delete(int id)
        {
            var productDb = await GetById(id);
            productDb.IsActive = false;
            await _context.SaveChangesAsync();

            return productDb;
        }

        public async Task<Product> Add(Product product)
        {
            product.Name = product.Name.Trim();
            product.IsActive = true;
            product.CreateDate = DateTime.Now.ToLocalTime();
            product.UpdateDate = DateTime.Now.ToLocalTime();
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<Product> Update(Product updatedProduct)
        {
            var oldProduct = await GetById(updatedProduct.Id);
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

            await _context.SaveChangesAsync();
            return oldProduct;
        }
    }
}
