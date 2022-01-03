using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopPanelModels;
using Common.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    //[TokenAuthenticationFilter]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProfileController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Profile>> GetById(int id)
        {
            var service = new CrudService<Profile>(_context);
            var profile = await service.GetById(id);

            return Ok(await service.GetById(profile.Id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Profile>> GetAll()
        {
            var service = new CrudService<Profile>(_context);
            return Ok(await service.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Profile>> Delete(int id)
        {
            var service = new CrudService<Profile>(_context);

            var employeeProfiles = await _context.EmployeesProfiles
                .AsQueryable()
                .Where(ep => ep.ProfileId == id)
                .ToListAsync();

            foreach (var employeeProfile in employeeProfiles)
                _context.EmployeesProfiles.Remove(employeeProfile);

            await service.Delete(id);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Profile>> Add([FromBody] Profile profile)
        {
            var service = new CrudService<Profile>(_context);
            profile.Name = profile.Name.Trim();

            return Ok(await service.Insert(profile));
        }

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

        [HttpGet("get-profiles-for-employee/{id}")]
        public async Task<ActionResult<List<Profile>>> GetProfilesForEmployee(int employeeId)
        {
            var db = await _context.Profiles
                .Include(p => p.EmployeesProfiles)
                .ToListAsync();
            var results = new List<Profile>();
            foreach(var result in db)
            {
                if (result.EmployeesProfiles.Any(p => p.EmployeeId == employeeId))
                    results.Add(result);
            }

            return Ok(results);
        }
    }
}
