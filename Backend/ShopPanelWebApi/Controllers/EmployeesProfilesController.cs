using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
    public class EmployeesProfilesController : ControllerBase
    {
        private readonly EmployeesProfilesService _employeesProfilesService;
        public EmployeesProfilesController(AppDbContext context)
        {
            _employeesProfilesService = new EmployeesProfilesService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<EmployeesProfiles>> FindOne(int employeeId, int profileId)
        {
            return Ok(await _employeesProfilesService.FindOne(employeeId, profileId));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeesProfiles>> Delete(int employeeId, int profileId)
        {
            return Ok(await _employeesProfilesService.Delete(employeeId, profileId));
        }

        [HttpPost]
        public async Task<ActionResult<EmployeesProfiles>> Add([FromBody] EmployeesProfiles employeesProfiles)
        {
            return Ok(await _employeesProfilesService.Add(employeesProfiles));
        }

        /*        [HttpPatch]
                public async Task<ActionResult<EmployeesProfiles>> Update([FromBody] EmployeesProfiles oldEmployeesProfiles, EmployeesProfiles newEmployeesProfiles)
                {
                    return Ok(await _employeesProfilesService.Update(oldEmployeesProfiles, newEmployeesProfiles));
                }*/

        [HttpPost]
        public async Task<ActionResult<EmployeesProfiles>> AddMany([FromBody] List<EmployeesProfiles> employeesProfilesList)
        {
            return Ok(await _employeesProfilesService.AddMany(employeesProfilesList));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeesProfiles>> RemoveMany(List<EmployeesProfiles> employeesProfilesList)
        {
            return Ok(await _employeesProfilesService.RemoveMany(employeesProfilesList));
        }
    }
}
