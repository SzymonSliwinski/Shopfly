using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Dtos;
using Common.Models.ShopModels;
using Microsoft.EntityFrameworkCore;

namespace Common.Services
{
    public class ProductsVariantsPhotosService
    {
        /*
        private readonly AppDbContext _context;
        public ProductsVariantsPhotosService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductsVariantsPhotos> FindOne(int productVariantId, int photoId)
        {
            var result = await _context.ProductsVariantsPhotos
                .AsQueryable()
                .SingleAsync(pvp => pvp.ProductVariantId == productVariantId && pvp.PhotoId == photoId);

            return result;
        }

        public async Task<ProductsVariantsPhotos> Delete(int productVariantId, int photoId)
        {
            var productsVariantsPhotosDb = await FindOne(productVariantId, photoId);
            _context.Remove(productsVariantsPhotosDb);
            await _context.SaveChangesAsync();

            return productsVariantsPhotosDb;
        }

        public async Task<ProductsVariantsPhotos> Add(ProductsVariantsPhotos productsVariantsPhotos)
        {
            var newProductsVariantsPhotos = new ProductsVariantsPhotos()
            {
                ProductVariantId = productsVariantsPhotos.ProductVariantId,
                PhotoId = productsVariantsPhotos.PhotoId
            };

            await _context.AddAsync(newProductsVariantsPhotos);
            await _context.SaveChangesAsync();

            return newProductsVariantsPhotos;
        }

        public async Task<ProductsVariantsPhotos> Update(UpdateModelDto<ProductsVariantsPhotos> modelsDto)
        {
            await Delete(modelsDto.OldModel.ProductVariantId, modelsDto.OldModel.PhotoId);
            await Add(modelsDto.NewModel);
            return modelsDto.NewModel;
        }

        public async Task<List<ProductsVariantsPhotos>> AddMany(List<ProductsVariantsPhotos> productsVariantsPhotosList)
        {
            foreach (var productsVariantsPhotos in productsVariantsPhotosList)
                await Add(productsVariantsPhotos);

            return productsVariantsPhotosList;
        }

        public async Task<List<ProductsVariantsPhotos>> RemoveMany(List<ProductsVariantsPhotos> productsVariantsPhotosList)
        {
            foreach (var productsVariantsPhotos in productsVariantsPhotosList)
                await Delete(productsVariantsPhotos.ProductVariantId, productsVariantsPhotos.PhotoId);

            return productsVariantsPhotosList;
        }
        */
    }
}
