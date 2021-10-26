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
        private readonly StatusService _statusService;
        public StatusController(AppDbContext context)
        {
            _statusService = new StatusService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Status>> GetById(int id)
        {
            return Ok(await _statusService.GetById(id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Status>> GetAll()
        {
            return Ok(await _statusService.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Status>> Delete(int id)
        {
            return Ok(await _statusService.Delete(id));
        }

        [HttpPost]
        public async Task<ActionResult<Status>> Add([FromBody] Status status)
        {
            return Ok(await _statusService.Add(status));
        }

        [HttpPatch]
        public async Task<ActionResult<Status>> Update([FromBody] Status status)
        {
            return Ok(await _statusService.Update(status));
        }
    }
}
