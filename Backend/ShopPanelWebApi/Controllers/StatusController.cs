using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopModels;
using Common.Services;
using ShopPanelWebApi.Filters;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    [TokenAuthenticationFilter]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly AppDbContext _context;
        public StatusController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Status>> GetById(int id)
        {
            var service = new CrudService<Status>(_context);
            var status = await service.GetById(id);

            return Ok(await service.GetById(status.Id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Status>> GetAll()
        {
            var service = new CrudService<Status>(_context);
            return Ok(await service.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Status>> Delete(int id)
        {
            var service = new CrudService<Status>(_context);
            await service.Delete(id);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Status>> Add([FromBody] Status status)
        {
            var service = new CrudService<Status>(_context);

            return Ok(await service.Insert(status));
        }

        [HttpPatch]
        public async Task<ActionResult<Status>> Update([FromBody] Status updatedStatus)
        {
            var service = new CrudService<Status>(_context);
            var oldStatus = await service.GetById(updatedStatus.Id);

            oldStatus.Name = updatedStatus.Name;

            return Ok(await service.Update(oldStatus));
        }

        [HttpGet("set-status/{statusId}/for-order/{orderId}")]
        public async Task ChangeStatusForOrder(int statusId, int orderId)
        {
            var order = await _context.Orders.Where(c => c.Id == orderId).SingleAsync();
            order.StatusId = statusId;
            if (statusId == 4)
                order.CompleteDate = System.DateTime.Now.ToLocalTime();
            await _context.SaveChangesAsync();

        }
    }
}
