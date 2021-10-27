using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopPanelModels;
using Common.Services;
using ShopPanelWebApi.Filters;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    [TokenAuthenticationFilter]
    [ApiController]
    public class PrivilegeController : ControllerBase
    {
        private readonly PrivilegeService _privilegeService;
        public PrivilegeController(AppDbContext context)
        {
            _privilegeService = new PrivilegeService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Privilege>> GetById(int id)
        {
            return Ok(await _privilegeService.GetById(id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Privilege>> GetAll()
        {
            return Ok(await _privilegeService.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Privilege>> Delete(int id)
        {
            return Ok(await _privilegeService.Delete(id));
        }

        [HttpPost]
        public async Task<ActionResult<Privilege>> Add([FromBody] Privilege privilege)
        {
            return Ok(await _privilegeService.Add(privilege));
        }

        [HttpPatch]
        public async Task<ActionResult<Privilege>> Update([FromBody] Privilege privilege)
        {
            return Ok(await _privilegeService.Update(privilege));
        }
    }
}
