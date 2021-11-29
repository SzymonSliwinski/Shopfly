using Common;
using Common.Models;
using Common.Services;
using Microsoft.AspNetCore.Mvc;
using ShopPanelWebApi.Filters;
using System.Threading.Tasks;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-settings")]
    [TokenAuthenticationFilter]
    [ApiController]
    public class ShopSettingsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly CrudService<ShopSettings> _dbService;
        public ShopSettingsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ShopSettings>> GetSettings()
        {
            return Ok(await _dbService.GetAll());
        }

        [HttpPatch]
        public async Task<ActionResult<ShopSettings>> Update([FromBody] ShopSettings payload)
        {
            return Ok(await _dbService.Update(payload));
        }
    }
}
