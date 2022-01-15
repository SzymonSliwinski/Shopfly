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
    public class ProductDimensionsController : ControllerBase
    {
        private readonly AppDbContext _productDimensionsService;
        public ProductDimensionsController(AppDbContext context)
        {
            _productDimensionsService = context;
        }

        [KeyAuthenticationFilter(Table = TableType.productDiemensions, Method = HttpMethodType.get)]
        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<ProductDimensions>> GetById(int id)
        {
            var service = new CrudService<ProductDimensions>(_productDimensionsService);
            var productDimensions = await service.GetById(id);

            return Ok(await service.GetById(productDimensions.Id));
        }

        [KeyAuthenticationFilter(Table = TableType.productDiemensions, Method = HttpMethodType.get)]
        [HttpGet("get-all")]
        public async Task<ActionResult<ProductDimensions>> GetAll()
        {
            var service = new CrudService<ProductDimensions>(_productDimensionsService);
            return Ok(await service.GetAll());
        }

        [KeyAuthenticationFilter(Table = TableType.productDiemensions, Method = HttpMethodType.delete)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var service = new CrudService<ProductDimensions>(_productDimensionsService);
            await service.Delete(id);

            return Ok();
        }

        [KeyAuthenticationFilter(Table = TableType.productDiemensions, Method = HttpMethodType.post)]
        [HttpPost]
        public async Task<ActionResult<ProductDimensions>> Add([FromBody] ProductDimensions productDimensions)
        {
            var service = new CrudService<ProductDimensions>(_productDimensionsService);

            return Ok(await service.Insert(productDimensions));
        }

        [KeyAuthenticationFilter(Table = TableType.productDiemensions, Method = HttpMethodType.patch)]
        [HttpPatch]
        public async Task<ActionResult<ProductDimensions>> Update([FromBody] ProductDimensions updatedProductDimensions)
        {
            var service = new CrudService<ProductDimensions>(_productDimensionsService);
            var oldProductDimensions = await service.GetById(updatedProductDimensions.Id);

            oldProductDimensions.Width = updatedProductDimensions.Width;
            oldProductDimensions.Height = updatedProductDimensions.Height;
            oldProductDimensions.Weight = updatedProductDimensions.Weight;

            return Ok(await service.Update(oldProductDimensions));
        }
    }
}
