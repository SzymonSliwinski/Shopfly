using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Common.Dtos;
using Common.Models.ApiModels;
using Common.Models.ShopPanelModels;
using Common.Services;
using OpenWebApi.Filters;

namespace OpenWebApi.Controllers
{
    [Route("api/employees-profiles")]
    [ApiController]
    public class EmployeesProfilesController : ControllerBase
    {
        private readonly EmployeesProfilesService _employeesProfilesService;
        public EmployeesProfilesController(AppDbContext context)
        {
            _employeesProfilesService = new EmployeesProfilesService(context);
        }

        [KeyAuthenticationFilter(Table = TableType.employeesProfiles, Method = HttpMethodType.get)]
        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<EmployeesProfiles>> FindOne(int employeeId, int profileId)
        {
            return Ok(await _employeesProfilesService.FindOne(employeeId, profileId));
        }

        [KeyAuthenticationFilter(Table = TableType.employeesProfiles, Method = HttpMethodType.delete)]
        [HttpPost("delete")]
        public async Task<ActionResult<EmployeesProfiles>> Delete([FromBody] EmployeesProfiles ep)
        {
            return Ok(await _employeesProfilesService.Delete(ep.EmployeeId, ep.ProfileId));
        }

        [KeyAuthenticationFilter(Table = TableType.employeesProfiles, Method = HttpMethodType.post)]
        [HttpPost("add-single")]
        public async Task<ActionResult<EmployeesProfiles>> Add([FromBody] EmployeesProfiles employeesProfiles)
        {
            return Ok(await _employeesProfilesService.Add(employeesProfiles));
        }

        [KeyAuthenticationFilter(Table = TableType.employeesProfiles, Method = HttpMethodType.patch)]
        [HttpPatch]
        public async Task<ActionResult<EmployeesProfiles>> Update([FromBody] UpdateModelDto<EmployeesProfiles> payload)
        {
            return Ok(await _employeesProfilesService.Update(payload));
        }

        [KeyAuthenticationFilter(Table = TableType.employeesProfiles, Method = HttpMethodType.post)]
        [HttpPost]
        public async Task<ActionResult<EmployeesProfiles>> AddMany([FromBody] List<EmployeesProfiles> employeesProfilesList)
        {
            return Ok(await _employeesProfilesService.AddMany(employeesProfilesList));
        }

        [KeyAuthenticationFilter(Table = TableType.employeesProfiles, Method = HttpMethodType.delete)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeesProfiles>> RemoveMany(List<EmployeesProfiles> employeesProfilesList)
        {
            return Ok(await _employeesProfilesService.RemoveMany(employeesProfilesList));
        }
    }
}
