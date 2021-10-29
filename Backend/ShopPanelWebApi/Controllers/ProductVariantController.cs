using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopModels;
using Common.Services;
using ShopPanelWebApi.Filters;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    [TokenAuthenticationFilter]
    [ApiController]
    public class ProductVariantController : ControllerBase
    {
        private readonly ProductVariantService _productVariantService;
        public ProductVariantController(AppDbContext context)
        {
            _productVariantService = new ProductVariantService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<ProductVariant>> GetById(int id)
        {
            return Ok(await _productVariantService.GetById(id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<ProductVariant>> GetAll()
        {
            return Ok(await _productVariantService.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductVariant>> Delete(int id)
        {
            return Ok(await _productVariantService.Delete(id));
        }

        [HttpPost]
        public async Task<ActionResult<ProductVariant>> Add([FromBody] ProductVariant productVariant)
        {
            return Ok(await _productVariantService.Add(productVariant));
        }

        [HttpPatch]
        public async Task<ActionResult<ProductVariant>> Update([FromBody] ProductVariant productVariant)
        {
            return Ok(await _productVariantService.Update(productVariant));
        }
    }
}
