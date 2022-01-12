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
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _categoryService;
        public CategoryController(AppDbContext context)
        {
            _categoryService = context;
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var service = new CrudService<Category>(_categoryService);
            var category = await service.GetById(id);

            return Ok(await service.GetById(category.Id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Category>> GetAll()
        {
            var service = new CrudService<Category>(_categoryService);
            return Ok(await service.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var service = new CrudService<Category>(_categoryService);
            var category = await service.GetById(id);
            category.IsActive = false;
            await service.Update(category);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Add([FromBody] Category category)
        {
            var service = new CrudService<Category>(_categoryService);
            category.Name = category.Name.Trim();
            return Ok(await service.Insert(category));
        }

        [HttpPatch]
        public async Task<ActionResult<Category>> Update([FromBody] Category updatedCategory)
        {
            var service = new CrudService<Category>(_categoryService);
            var oldCategory = await service.GetById(updatedCategory.Id);

            oldCategory.Name = updatedCategory.Name.Trim();
            oldCategory.IsRoot = updatedCategory.IsRoot;
            oldCategory.ParentCategoryId = updatedCategory.ParentCategoryId;
            oldCategory.Position = updatedCategory.Position;

            return Ok(await service.Update(oldCategory));
        }
    }
}
