using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopModels;
using Common.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CommentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Comment>> GetById(int id)
        {
            var service = new CrudService<Comment>(_context);
            var comment = await service.GetById(id);

            return Ok(await service.GetById(comment.Id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Comment>> GetAll()
        {
            var service = new CrudService<Comment>(_context);
            return Ok(await service.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var service = new CrudService<Comment>(_context);
            await service.Delete(id);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> Add([FromBody] Comment comment)
        {
            var service = new CrudService<Comment>(_context);

            comment.Content = comment.Content.Trim();
            comment.CreateDate = DateTime.Now.ToLocalTime();
            var result = await service.Insert(comment);
            result.Customer = await _context.Customers.Where(c => c.Id == comment.CustomerId).SingleAsync();
            return Ok(result);
        }

        [HttpPatch]
        public async Task<ActionResult<Comment>> Update([FromBody] Comment updatedComment)
        {
            var service = new CrudService<Comment>(_context);
            var oldComment = await service.GetById(updatedComment.Id);

            oldComment.Content = updatedComment.Content.Trim();

            return Ok(await service.Update(oldComment));
        }

    }
}
