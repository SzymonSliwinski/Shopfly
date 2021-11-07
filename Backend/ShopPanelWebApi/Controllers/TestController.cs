using ShopPanelWebApi.Filters;
using Microsoft.AspNetCore.Mvc;
using Common.Services;
using Common.Models.ShopModels;
using Common;
using System.Threading.Tasks;
using Common.Models.ShopPanelModels;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    [ApiController]
    // [TokenAuthenticationFilter]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TestController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<string>> TestAuthentication([FromBody] ProfilesPrivileges prod)
        {
            var service = new ManyToManyCrudService<ProfilesPrivileges>(_context);
            //var a = await service.Insert(prod);
            service.Delete(prod.ProfileId, prod.PrivilegeId);
            return Ok("Hello world");
        }
    }
}
