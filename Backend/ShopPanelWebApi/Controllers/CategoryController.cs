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
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoryController(AppDbContext context)
        {
            _categoryService = new CategoryService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            return Ok(await _categoryService.GetById(id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Category>> GetAll()
        {
            return Ok(await _categoryService.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> Delete(int id)
        {
            return Ok(await _categoryService.Delete(id));
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Add([FromBody] Category category)
        {
            return Ok(await _categoryService.Add(category));
        }

        [HttpPatch]
        public async Task<ActionResult<Category>> Update([FromBody] Category category)
        {
            return Ok(await _categoryService.Update(category));
        }
    }
}
