using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ApiModels;
using Common.Models.ShopModels;
using Common.Services;
using OpenWebApi.Filters;

namespace OpenWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariantController : ControllerBase
    {
        private readonly AppDbContext _productVariantService;
        public ProductVariantController(AppDbContext context)
        {
            _productVariantService = context;
        }

        [KeyAuthenticationFilter(Table = TableType.productsVariants, Method = HttpMethodType.get)]
        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<ProductVariant>> GetById(int id)
        {
            var service = new CrudService<ProductVariant>(_productVariantService);
            var productVariant = await service.GetById(id);

            return Ok(await service.GetById(productVariant.Id));
        }

        [KeyAuthenticationFilter(Table = TableType.productsVariants, Method = HttpMethodType.get)]
        [HttpGet("get-all")]
        public async Task<ActionResult<ProductVariant>> GetAll()
        {
            var service = new CrudService<ProductVariant>(_productVariantService);
            return Ok(await service.GetAll());
        }

        [KeyAuthenticationFilter(Table = TableType.productsVariants, Method = HttpMethodType.delete)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductVariant>> Delete(int id)
        {
            var service = new CrudService<ProductVariant>(_productVariantService);
            var productVariant = await service.GetById(id);

            await service.Update(productVariant);
            return Ok();
        }

        [KeyAuthenticationFilter(Table = TableType.productsVariants, Method = HttpMethodType.post)]
        [HttpPost]
        public async Task<ActionResult<ProductVariant>> Add([FromBody] ProductVariant productVariant)
        {
            var service = new CrudService<ProductVariant>(_productVariantService);

            return Ok(await service.Insert(productVariant));
        }

        [KeyAuthenticationFilter(Table = TableType.productsVariants, Method = HttpMethodType.patch)]
        [HttpPatch]
        public async Task<ActionResult<ProductVariant>> Update([FromBody] ProductVariant updatedProductVariant)
        {
            var service = new CrudService<ProductVariant>(_productVariantService);
            var oldProductVariant = await service.GetById(updatedProductVariant.Id);

            oldProductVariant.ColorId = updatedProductVariant.ColorId;
            oldProductVariant.DimensionId = updatedProductVariant.DimensionId;
            oldProductVariant.Price = updatedProductVariant.Price;
            oldProductVariant.IsOnSale = updatedProductVariant.IsOnSale;
            oldProductVariant.SalePercentage = updatedProductVariant.SalePercentage;
            oldProductVariant.Quantity = updatedProductVariant.Quantity;
            oldProductVariant.ProductId = updatedProductVariant.ProductId;

            return Ok(await service.Update(oldProductVariant));
        }
    }
}
