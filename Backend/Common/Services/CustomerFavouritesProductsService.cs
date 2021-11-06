using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Dtos;
using Common.Models.ShopModels;
using Microsoft.EntityFrameworkCore;

namespace Common.Services
{
    public class CustomerFavouritesProductsService
    {
        private readonly AppDbContext _context;
        public CustomerFavouritesProductsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerFavouritesProducts> FindOne(int customerId, int productId)
        {
            var result = await _context.CustomerFavouritesProducts
                .AsQueryable()
                .SingleAsync(cfp => cfp.CustomerId == customerId && cfp.ProductId == productId);

            return result;
        }

        public async Task<CustomerFavouritesProducts> Delete(int customerId, int productId)
        {
            var customerFavouritesProductsDb = await FindOne(customerId, productId);
            _context.Remove(customerFavouritesProductsDb);
            await _context.SaveChangesAsync();

            return customerFavouritesProductsDb;
        }

        public async Task<CustomerFavouritesProducts> Add(CustomerFavouritesProducts customerFavouritesProducts)
        {
            var newCustomerFavouritesProducts = new CustomerFavouritesProducts()
            {
                CustomerId = customerFavouritesProducts.CustomerId,
                ProductId = customerFavouritesProducts.ProductId
            };

            await _context.AddAsync(newCustomerFavouritesProducts);
            await _context.SaveChangesAsync();

            return newCustomerFavouritesProducts;
        }

        public async Task<CustomerFavouritesProducts> Update(UpdateModelDto<CustomerFavouritesProducts> modelsDto)
        {
            await Delete(modelsDto.OldModel.CustomerId, modelsDto.OldModel.ProductId);
            await Add(modelsDto.NewModel);
            return modelsDto.NewModel;
        }

        public async Task<List<CustomerFavouritesProducts>> AddMany(List<CustomerFavouritesProducts> customerFavouritesProductsList)
        {
            foreach (var customerFavouritesProducts in customerFavouritesProductsList)
                await Add(customerFavouritesProducts);

            return customerFavouritesProductsList;
        }

        public async Task<List<CustomerFavouritesProducts>> RemoveMany(List<CustomerFavouritesProducts> customerFavouritesProductsList)
        {
            foreach (var customerFavouritesProducts in customerFavouritesProductsList)
                await Delete(customerFavouritesProducts.CustomerId, customerFavouritesProducts.ProductId);

            return customerFavouritesProductsList;
        }
    }
}
