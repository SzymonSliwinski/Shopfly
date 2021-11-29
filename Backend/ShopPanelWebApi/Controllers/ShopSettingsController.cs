using Common;
using Common.Models;
using Common.Services;
using Microsoft.AspNetCore.Mvc;
using ShopPanelWebApi.Filters;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Returns all records from settings table, if theres no record creates new entry with basic values
        /// and saves it to db
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ShopSettings>> GetSettingsOrCreateBasic()
        {
            var settings = await _dbService.GetAll();
            if (settings == null)
                settings = new List<ShopSettings>();
            if (settings.Count() == 0)
            {
                var defaultSettings = new ShopSettings();
                defaultSettings.SetDefaultSettings();
                settings.Add(defaultSettings);
            }

            return Ok(settings.First());
        }
        /// <summary>
        ///  updates settings with given object in body
        /// </summary>
        /// <param name="payload">updated ShopSettings</param>
        /// <returns></returns>

        [HttpPatch]
        public async Task<ActionResult<ShopSettings>> Update([FromBody] ShopSettings payload)
        {
            return Ok(await _dbService.Update(payload));
        }
    }
}
