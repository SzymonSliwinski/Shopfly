using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Dtos;
using Common.Models.ShopModels;
using Microsoft.EntityFrameworkCore;

namespace Common.Services
{
    public class OrdersProductsService
    {
        private readonly AppDbContext _context;
        public OrdersProductsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<OrdersProducts> FindOne(int orderId, int productId)
        {
            var result = await _context.OrdersProducts
                .AsQueryable()
                .SingleAsync(op => op.OrderId == orderId && op.ProductId == productId);

            return result;
        }

        public async Task<OrdersProducts> Delete(int orderId, int productId)
        {
            var ordersProductsDb = await FindOne(orderId, productId);
            _context.Remove(ordersProductsDb);
            await _context.SaveChangesAsync();

            return ordersProductsDb;
        }

        public async Task<OrdersProducts> Add(OrdersProducts ordersProducts)
        {
            var newOrdersProducts = new OrdersProducts()
            {
                OrderId = ordersProducts.OrderId,
                ProductId = ordersProducts.ProductId
            };

            await _context.AddAsync(newOrdersProducts);
            await _context.SaveChangesAsync();

            return newOrdersProducts;
        }

        public async Task<OrdersProducts> Update(UpdateModelDto<OrdersProducts> modelsDto)
        {
            await Delete(modelsDto.OldModel.OrderId, modelsDto.OldModel.ProductId);
            await Add(modelsDto.NewModel);
            return modelsDto.NewModel;
        }

        public async Task<List<OrdersProducts>> AddMany(List<OrdersProducts> ordersProductsList)
        {
            foreach (var ordersProducts in ordersProductsList)
                await Add(ordersProducts);

            return ordersProductsList;
        }

        public async Task<List<OrdersProducts>> RemoveMany(List<OrdersProducts> ordersProductsList)
        {
            foreach (var ordersProducts in ordersProductsList)
                await Delete(ordersProducts.OrderId, ordersProducts.ProductId);

            return ordersProductsList;
        }
    }
}
