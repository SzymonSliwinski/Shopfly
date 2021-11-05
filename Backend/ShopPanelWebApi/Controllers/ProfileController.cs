using System.Threading.Tasks;
using Common;
using Common.Models.ShopPanelModels;
using Common.Services;
using Microsoft.AspNetCore.Mvc;
using ShopPanelWebApi.Filters;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    [TokenAuthenticationFilter]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileService _profileService;
        public ProfileController(AppDbContext context)
        {
            _profileService = new ProfileService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Profile>> GetById(int id)
        {
            return Ok(await _profileService.GetById(id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Profile>> GetAll()
        {
            return Ok(await _profileService.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Profile>> Delete(int id)
        {
            return Ok(await _profileService.Delete(id));
        }

        [HttpPost]
        public async Task<ActionResult<Profile>> Add([FromBody] Profile profile)
        {
            return Ok(await _profileService.Add(profile));
        }

        [HttpPatch]
        public async Task<ActionResult<Profile>> Update([FromBody] Profile profile)
        {
            return Ok(await _profileService.Update(profile));
        }
    }
}
