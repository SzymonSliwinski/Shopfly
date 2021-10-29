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
    public class CommentController : ControllerBase
    {
        private readonly CommentService _commentService;
        public CommentController(AppDbContext context)
        {
            _commentService = new CommentService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Comment>> GetById(int id)
        {
            return Ok(await _commentService.GetById(id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Comment>> GetAll()
        {
            return Ok(await _commentService.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Comment>> Delete(int id)
        {
            return Ok(await _commentService.Delete(id));
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> Add([FromBody] Comment comment)
        {
            return Ok(await _commentService.Add(comment));
        }

        [HttpPatch]
        public async Task<ActionResult<Comment>> Update([FromBody] Comment comment)
        {
            return Ok(await _commentService.Update(comment));
        }

    }
}
