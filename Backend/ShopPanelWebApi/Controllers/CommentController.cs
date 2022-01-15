using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopModels;
using Common.Services;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly AppDbContext _commentService;
        public CommentController(AppDbContext context)
        {
            _commentService = context;
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Comment>> GetById(int id)
        {
            var service = new CrudService<Comment>(_commentService);
            var comment = await service.GetById(id);

            return Ok(await service.GetById(comment.Id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Comment>> GetAll()
        {
            var service = new CrudService<Comment>(_commentService);
            return Ok(await service.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var service = new CrudService<Comment>(_commentService);
            await service.Delete(id);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> Add([FromBody] Comment comment)
        {
            var service = new CrudService<Comment>(_commentService);

            comment.Content = comment.Content.Trim();
            comment.CreateDate = DateTime.Now.ToLocalTime();

            return Ok(await service.Insert(comment));
        }

        [HttpPatch]
        public async Task<ActionResult<Comment>> Update([FromBody] Comment updatedComment)
        {
            var service = new CrudService<Comment>(_commentService);
            var oldComment = await service.GetById(updatedComment.Id);

            oldComment.Content = updatedComment.Content.Trim();

            return Ok(await service.Update(oldComment));
        }

    }
}
