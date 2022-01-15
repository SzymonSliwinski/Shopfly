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
    public class StatusController : ControllerBase
    {
        private readonly AppDbContext _statusService;
        public StatusController(AppDbContext context)
        {
            _statusService = context;
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Status>> GetById(int id)
        {
            var service = new CrudService<Status>(_statusService);
            var status = await service.GetById(id);

            return Ok(await service.GetById(status.Id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Status>> GetAll()
        {
            var service = new CrudService<Status>(_statusService);
            return Ok(await service.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Status>> Delete(int id)
        {
            var service = new CrudService<Status>(_statusService);
            await service.Delete(id);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Status>> Add([FromBody] Status status)
        {
            var service = new CrudService<Status>(_statusService);

            return Ok(await service.Insert(status));
        }

        [HttpPatch]
        public async Task<ActionResult<Status>> Update([FromBody] Status updatedStatus)
        {
            var service = new CrudService<Status>(_statusService);
            var oldStatus = await service.GetById(updatedStatus.Id);

            oldStatus.Name = updatedStatus.Name;

            return Ok(await service.Update(oldStatus));
        }
    }
}
