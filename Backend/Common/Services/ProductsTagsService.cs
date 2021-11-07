using Common.Models.ShopModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Dtos;

namespace Common.Services
{
    public class ProductsTagsService
    {
        private readonly AppDbContext _context;
        public ProductsTagsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductsTags> FindOne(int tagId, int productId)
        {
            var result = await _context.ProductsTags
                .AsQueryable()
                .SingleAsync(pt => pt.ProductId == productId && pt.TagId == tagId);

            return result;
        }

        public async Task<ProductsTags> Delete(int tagId, int productId)
        {
            var productsTagsDb = await FindOne(tagId, productId);
            _context.Remove(productsTagsDb);
            await _context.SaveChangesAsync();

            return productsTagsDb;
        }

        public async Task<ProductsTags> Add(ProductsTags productsTags)
        {
            var newProductsTags = new ProductsTags()
            {
                ProductId = productsTags.ProductId,
                TagId = productsTags.TagId
            };

            await _context.AddAsync(newProductsTags);
            await _context.SaveChangesAsync();

            return newProductsTags;
        }

        public async Task<ProductsTags> Update(UpdateModelDto<ProductsTags> modelsDto)
        {
            await Delete(modelsDto.OldModel.TagId, modelsDto.OldModel.ProductId);
            await Add(modelsDto.NewModel);
            return modelsDto.NewModel;
        }

        public async Task<List<ProductsTags>> AddMany(List<ProductsTags> productsTagsList)
        {
            foreach (var productsTags in productsTagsList)
                await Add(productsTags);

            return productsTagsList;
        }

        public async Task<List<ProductsTags>> RemoveMany(List<ProductsTags> productsTagsList)
        {
            foreach (var productsTags in productsTagsList)
                await Delete(productsTags.TagId, productsTags.ProductId);

            return productsTagsList;
        }
    }
}
