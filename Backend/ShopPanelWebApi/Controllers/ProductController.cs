using System;
using Common;
using Common.Models.ShopModels;
using Common.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    //[TokenAuthenticationFilter]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _productService;
        public ProductController(AppDbContext context)
        {
            _productService = context;
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var service = new CrudService<Product>(_productService);
            var product = await service.GetById(id);

            return Ok(await service.GetById(product.Id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Product>> GetAll()
        {
            var service = new CrudService<Product>(_productService);
            return Ok(await service.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            var service = new CrudService<Product>(_productService);
            var product = await service.GetById(id);

            product.IsActive = false;

            await service.Update(product);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Add([FromBody] Product product)
        {
            var service = new CrudService<Product>(_productService);

            product.Name = product.Name.Trim();
            product.IsActive = true;
            product.CreateDate = DateTime.Now.ToLocalTime();
            product.UpdateDate = DateTime.Now.ToLocalTime();

            return Ok(await service.Insert(product));
        }

        [HttpPatch]
        public async Task<ActionResult<Product>> Update([FromBody] Product updatedProduct)
        {
            var service = new CrudService<Product>(_productService);
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
