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
    public class ProductColorController : ControllerBase
    {
        private readonly ProductColorService _productColorService;
        public ProductColorController(AppDbContext context)
        {
            _productColorService = new ProductColorService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<ProductColor>> GetById(int id)
        {
            return Ok(await _productColorService.GetById(id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<ProductColor>> GetAll()
        {
            return Ok(await _productColorService.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductColor>> Delete(int id)
        {
            return Ok(await _productColorService.Delete(id));
        }

        [HttpPost]
        public async Task<ActionResult<ProductColor>> Add([FromBody] ProductColor productColor)
        {
            return Ok(await _productColorService.Add(productColor));
        }

        [HttpPatch]
        public async Task<ActionResult<ProductColor>> Update([FromBody] ProductColor productColor)
        {
            return Ok(await _productColorService.Update(productColor));
        }
    }
}
