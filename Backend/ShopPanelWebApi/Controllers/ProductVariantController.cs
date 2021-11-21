using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopModels;
using Common.Services;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    //[TokenAuthenticationFilter]
    [ApiController]
    public class ProductVariantController : ControllerBase
    {
        private readonly AppDbContext _productVariantService;
        public ProductVariantController(AppDbContext context)
        {
            _productVariantService = context;
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<ProductVariant>> GetById(int id)
        {
            var service = new CrudService<ProductVariant>(_productVariantService);
            var productVariant = await service.GetById(id);

            return Ok(await service.GetById(productVariant.Id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<ProductVariant>> GetAll()
        {
            var service = new CrudService<ProductVariant>(_productVariantService);
            return Ok(await service.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductVariant>> Delete(int id)
        {
            var service = new CrudService<ProductVariant>(_productVariantService);
            var productVariant = await service.GetById(id);

            await service.Update(productVariant);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<ProductVariant>> Add([FromBody] ProductVariant productVariant)
        {
            var service = new CrudService<ProductVariant>(_productVariantService);

            return Ok(await service.Insert(productVariant));
        }

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
