using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopModels;
using Common.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ShopPanelWebApi.Filters;
using System.Collections.Generic;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    [TokenAuthenticationFilter]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        private CrudService<Category> _service;
        public CategoryController(AppDbContext context)
        {
            _context = context;
            _service = new CrudService<Category>(_context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var service = new CrudService<Category>(_context);
            var category = await service.GetById(id);

            return Ok(await service.GetById(category.Id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<Category>>> GetAll()
        {
            return Ok(await _context.Categories.AsQueryable().Where(c => c.IsActive).ToListAsync());
        }


        [HttpGet("get-childrens")]
        public async Task<ActionResult<List<Category>>> GetOnlyChilds()
        {
            return Ok(await _context.Categories.AsQueryable().Where(c => c.ChildrensCategories.Count == 0 && c.IsActive).OrderBy(c => c.Name).ToListAsync()); ;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _service.GetById(id);
            category.IsActive = false;
            await _service.Update(category);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Add([FromBody] Category category)
        {
            category.Name = category.Name.Trim();
            return Ok(await _service.Insert(category));
        }

        [HttpPatch]
        public async Task<ActionResult<Category>> Update([FromBody] Category updatedCategory)
        {
            var oldCategory = await _service.GetById(updatedCategory.Id);

            oldCategory.Name = updatedCategory.Name.Trim();
            oldCategory.IsRoot = updatedCategory.IsRoot;
            oldCategory.ParentCategoryId = updatedCategory.ParentCategoryId;
            oldCategory.Position = updatedCategory.Position;

            return Ok(await _service.Update(oldCategory));
        }
    }
}
