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
    public class TagController : ControllerBase
    {
        private readonly AppDbContext _tagService;
        public TagController(AppDbContext context)
        {
            _tagService = context;
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Tag>> GetById(int id)
        {
            var service = new CrudService<Tag>(_tagService);
            var tag = await service.GetById(id);

            return Ok(await service.GetById(tag.Id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Tag>> GetAll()
        {
            var service = new CrudService<Tag>(_tagService);
            return Ok(await service.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Tag>> Delete(int id)
        {
            var service = new CrudService<Tag>(_tagService);
            await service.Delete(id);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Tag>> Add([FromBody] Tag tag)
        {
            var service = new CrudService<Tag>(_tagService);

            tag.Name = tag.Name.Trim();

            return Ok(await service.Insert(tag));
        }

        [HttpPatch]
        public async Task<ActionResult<Tag>> Update([FromBody] Tag updatedTag)
        {
            var service = new CrudService<Tag>(_tagService);
            var oldTag = await service.GetById(updatedTag.Id);

            oldTag.Name = updatedTag.Name.Trim();

            return Ok(await service.Update(oldTag));
        }
    }
}
