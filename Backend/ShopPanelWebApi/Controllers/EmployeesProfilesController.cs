using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Common.Dtos;
using Common.Models.ShopPanelModels;
using Common.Services;
using ShopPanelWebApi.Filters;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/employees-profiles")]
    //[TokenAuthenticationFilter]
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

        [HttpPost("delete")]
        public async Task<ActionResult<EmployeesProfiles>> Delete([FromBody] EmployeesProfiles ep)
        {
            return Ok(await _employeesProfilesService.Delete(ep.EmployeeId, ep.ProfileId));
        }

        [HttpPost("add-single")]
        public async Task<ActionResult<EmployeesProfiles>> Add([FromBody] EmployeesProfiles employeesProfiles)
        {
            return Ok(await _employeesProfilesService.Add(employeesProfiles));
        }

        [HttpPatch]
        public async Task<ActionResult<EmployeesProfiles>> Update([FromBody] UpdateModelDto<EmployeesProfiles> payload)
        {
            return Ok(await _employeesProfilesService.Update(payload));
        }

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
