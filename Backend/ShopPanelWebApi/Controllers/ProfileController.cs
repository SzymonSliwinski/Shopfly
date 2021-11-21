using System.Threading.Tasks;
using Common;
using Common.Models.ShopPanelModels;
using Common.Services;
using Microsoft.AspNetCore.Mvc;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    //[TokenAuthenticationFilter]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly AppDbContext _profileService;
        public ProfileController(AppDbContext context)
        {
            _profileService = context;
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Profile>> GetById(int id)
        {
            var service = new CrudService<Profile>(_profileService);
            var profile = await service.GetById(id);

            return Ok(await service.GetById(profile.Id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Profile>> GetAll()
        {
            var service = new CrudService<Profile>(_profileService);
            return Ok(await service.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Profile>> Delete(int id)
        {
            var service = new CrudService<Profile>(_profileService);
            var profile = await service.GetById(id);

            await service.Update(profile);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Profile>> Add([FromBody] Profile profile)
        {
            var service = new CrudService<Profile>(_profileService);

            profile.Name = profile.Name.Trim();

            return Ok(await service.Insert(profile));
        }

        [HttpPatch]
        public async Task<ActionResult<Profile>> Update([FromBody] Profile updatedProfile)
        {
            var service = new CrudService<Profile>(_profileService);
            var oldProfile = await service.GetById(updatedProfile.Id);

            oldProfile.Name = updatedProfile.Name;

            return Ok(await service.Update(oldProfile));
        }
    }
}
