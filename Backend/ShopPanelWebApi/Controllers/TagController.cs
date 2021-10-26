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
        private readonly TagService _tagService;
        public TagController(AppDbContext context)
        {
            _tagService = new TagService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Tag>> GetById(int id)
        {
            return Ok(await _tagService.GetById(id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Tag>> GetAll()
        {
            return Ok(await _tagService.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Tag>> Delete(int id)
        {
            return Ok(await _tagService.Delete(id));
        }

        [HttpPost]
        public async Task<ActionResult<Tag>> Add([FromBody] Tag tag)
        {
            return Ok(await _tagService.Add(tag));
        }

        [HttpPatch]
        public async Task<ActionResult<Tag>> Update([FromBody] Tag tag)
        {
            return Ok(await _tagService.Update(tag));
        }
    }
}
