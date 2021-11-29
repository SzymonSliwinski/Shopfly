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
        private readonly AppDbContext _privilegeService;
        public PrivilegeController(AppDbContext context)
        {
            _privilegeService = context;
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Privilege>> GetById(int id)
        {
            var service = new CrudService<Privilege>(_privilegeService);
            var privilege = await service.GetById(id);

            return Ok(await service.GetById(privilege.Id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Privilege>> GetAll()
        {
            var service = new CrudService<Privilege>(_privilegeService);
            return Ok(await service.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var service = new CrudService<Privilege>(_privilegeService);
            var privilege = await service.GetById(id);

            await service.Update(privilege);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Privilege>> Add([FromBody] Privilege privilege)
        {
            var service = new CrudService<Privilege>(_privilegeService);

            privilege.Name = privilege.Name.Trim();

            return Ok(await service.Insert(privilege));
        }

        [HttpPatch]
        public async Task<ActionResult<Privilege>> Update([FromBody] Privilege updatedPrivilege)
        {
            var service = new CrudService<Privilege>(_privilegeService);
            var oldPrivilege = await service.GetById(updatedPrivilege.Id);

            oldPrivilege.Name = updatedPrivilege.Name;

            return Ok(await service.Update(oldPrivilege));
        }
    }
}
