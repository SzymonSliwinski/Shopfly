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
    public class ProductDimensionsController : ControllerBase
    {
        private readonly ProductDimensionsService _productDimensionsService;
        public ProductDimensionsController(AppDbContext context)
        {
            _productDimensionsService = new ProductDimensionsService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<ProductDimensions>> GetById(int id)
        {
            return Ok(await _productDimensionsService.GetById(id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<ProductDimensions>> GetAll()
        {
            return Ok(await _productDimensionsService.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDimensions>> Delete(int id)
        {
            return Ok(await _productDimensionsService.Delete(id));
        }

        [HttpPost]
        public async Task<ActionResult<ProductDimensions>> Add([FromBody] ProductDimensions productDimensions)
        {
            return Ok(await _productDimensionsService.Add(productDimensions));
        }

        [HttpPatch]
        public async Task<ActionResult<ProductDimensions>> Update([FromBody] ProductDimensions productDimensions)
        {
            return Ok(await _productDimensionsService.Update(productDimensions));
        }
    }
}
