using System.Collections.Generic;
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
    public class ProfilesPrivilegesController : ControllerBase
    {
        private readonly ProfilesPrivilegesService _profilesPrivilegesService;
        public ProfilesPrivilegesController(AppDbContext context)
        {
            _profilesPrivilegesService = new ProfilesPrivilegesService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<ProfilesPrivileges>> FindOne(int profileId, int privilegeId)
        {
            return Ok(await _profilesPrivilegesService.FindOne(profileId, privilegeId));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProfilesPrivileges>> Delete(int profileId, int privilegeId)
        {
            return Ok(await _profilesPrivilegesService.Delete(profileId, privilegeId));
        }

        [HttpPost]
        public async Task<ActionResult<ProfilesPrivileges>> Add([FromBody] ProfilesPrivileges profilesPrivileges)
        {
            return Ok(await _profilesPrivilegesService.Add(profilesPrivileges));
        }

        /*        [HttpPatch]
                public async Task<ActionResult<ProfilesPrivileges>> Update([FromBody] ProfilesPrivileges oldProfilesPrivileges, ProfilesPrivileges newProfilesPrivileges)
                {
                    return Ok(await _profilesPrivilegesService.Update(oldProfilesPrivileges, newProfilesPrivileges));
                }*/

        [HttpPost]
        public async Task<ActionResult<ProfilesPrivileges>> AddMany([FromBody] List<ProfilesPrivileges> profilesPrivilegesList)
        {
            return Ok(await _profilesPrivilegesService.AddMany(profilesPrivilegesList));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProfilesPrivileges>> RemoveMany(List<ProfilesPrivileges> profilesPrivilegesList)
        {
            return Ok(await _profilesPrivilegesService.RemoveMany(profilesPrivilegesList));
        }
    }
}
