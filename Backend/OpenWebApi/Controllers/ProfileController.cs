using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Common.Models.ApiModels;
using Common.Models.ShopPanelModels;
using Common.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenWebApi.Filters;

namespace OpenWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProfileController(AppDbContext context)
        {
            _context = context;
        }

        [KeyAuthenticationFilter(Table = TableType.profiles, Method = HttpMethodType.get)]
        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Profile>> GetById(int id)
        {
            var service = new CrudService<Profile>(_context);
            var profile = await service.GetById(id);

            return Ok(await service.GetById(profile.Id));
        }

        [KeyAuthenticationFilter(Table = TableType.profiles, Method = HttpMethodType.get)]
        [HttpGet("get-all")]
        public async Task<ActionResult<Profile>> GetAll()
        {
            var service = new CrudService<Profile>(_context);
            return Ok(await service.GetAll());
        }

        [KeyAuthenticationFilter(Table = TableType.profiles, Method = HttpMethodType.delete)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Profile>> Delete(int id)
        {
            var service = new CrudService<Profile>(_context);

            var employeeProfiles = await _context.EmployeesProfiles
                .AsQueryable()
                .Where(ep => ep.ProfileId == id)
                .ToListAsync();

            _context.EmployeesProfiles.RemoveRange(employeeProfiles);
            await service.Delete(id);
            _context.SaveChanges();
            return Ok();
        }

        [KeyAuthenticationFilter(Table = TableType.profiles, Method = HttpMethodType.post)]
        [HttpPost]
        public async Task<ActionResult<Profile>> Add([FromBody] Profile profile)
        {
            var service = new CrudService<Profile>(_context);
            profile.Name = profile.Name.Trim();

            return Ok(await service.Insert(profile));
        }

        [KeyAuthenticationFilter(Table = TableType.profiles, Method = HttpMethodType.patch)]
        [HttpPatch]
        public async Task<ActionResult<Profile>> Update([FromBody] Profile updatedProfile)
        {
            var service = new CrudService<Profile>(_context);
            var oldProfile = await service.GetById(updatedProfile.Id);

            oldProfile.Name = updatedProfile.Name.Trim();
            oldProfile.HasAccessToApi = updatedProfile.HasAccessToApi;
            oldProfile.HasAccessToCharts = updatedProfile.HasAccessToCharts;
            oldProfile.HasAccessToCustomers = updatedProfile.HasAccessToCustomers;
            oldProfile.HasAccessToEmployees = updatedProfile.HasAccessToEmployees;
            oldProfile.HasAccessToImports = updatedProfile.HasAccessToImports;
            oldProfile.HasAccessToProducts = updatedProfile.HasAccessToProducts;
            oldProfile.HasAccessToSettings = updatedProfile.HasAccessToSettings;
            oldProfile.HasAccessToOrders = updatedProfile.HasAccessToOrders;

            return Ok(await service.Update(oldProfile));
        }

        [KeyAuthenticationFilter(Table = TableType.profiles, Method = HttpMethodType.get)]
        [HttpGet("get-profiles-for-employee/{employeeId}")]
        public async Task<ActionResult<List<Profile>>> GetProfilesForEmployee(int employeeId)
        {
            var db = await _context.Profiles
                .Include(p => p.EmployeesProfiles)
                .ToListAsync();
            var results = new List<Profile>();
            foreach (var result in db)
            {
                if (result.EmployeesProfiles.Any(p => p.EmployeeId == employeeId))
                    results.Add(result);
            }

            return Ok(results);
        }
    }
}
