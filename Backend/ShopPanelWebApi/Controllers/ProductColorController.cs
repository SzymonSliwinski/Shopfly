using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopModels;
using Common.Services;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    [ApiController]
    public class ProductColorController : ControllerBase
    {
        private readonly AppDbContext _productColorService;
        public ProductColorController(AppDbContext context)
        {
            _productColorService = context;
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<ProductColor>> GetById(int id)
        {
            var service = new CrudService<ProductColor>(_productColorService);
            var productColor = await service.GetById(id);

            return Ok(await service.GetById(productColor.Id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<ProductColor>> GetAll()
        {
            var service = new CrudService<ProductColor>(_productColorService);
            return Ok(await service.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var service = new CrudService<ProductColor>(_productColorService);
            await service.Delete(id);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<ProductColor>> Add([FromBody] ProductColor productColor)
        {
            var service = new CrudService<ProductColor>(_productColorService);

            productColor.HexValue = productColor.HexValue.Trim();

            return Ok(await service.Insert(productColor));
        }

        [HttpPatch]
        public async Task<ActionResult<ProductColor>> Update([FromBody] ProductColor updatedProductColor)
        {
            var service = new CrudService<ProductColor>(_productColorService);
            var oldProductColor = await service.GetById(updatedProductColor.Id);

            oldProductColor.HexValue = updatedProductColor.HexValue.Trim();

            return Ok(await service.Update(oldProductColor));
        }
    }
}
