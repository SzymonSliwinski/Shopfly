using Common;
using Common.Models;
using Common.Services;
using Microsoft.AspNetCore.Mvc;
using ShopPanelWebApi.Filters;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Diagnostics;
using System;
using Common.Utilieties;
using Common.Dtos;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/shop-settings")]
    [TokenAuthenticationFilter]
    [ApiController]
    public class ShopSettingsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly CrudService<ShopSettings> _dbService;
        public ShopSettingsController(AppDbContext context)
        {
            _context = context;
            _dbService = new CrudService<ShopSettings>(_context);
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
                defaultSettings.SetDefaultValues();
                settings.Add(defaultSettings);
                await _dbService.Insert(settings.First());
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

        /// <summary>
        /// receives file from frontend, generates unique name for it and saves it in proper path
        /// returns path to this file, not successed returns empty string
        /// </summary>
        /// <param name="file">photo</param>
        /// <returns></returns>
        [HttpPost("settings-photo")]
        public async Task<ActionResult<SettingsPhotoDto>> SetSettingsPhoto(IFormFile file)
        {
            if (file.Length > 0)
            {
                var (filePath, fileName) = Utility.GetSettingsPhotosPathAndUniqueFileName();
                var extension = Path.GetExtension(file.FileName);
                var fullFileName = filePath + fileName + extension;
                using (Stream fileStream = new FileStream(fullFileName, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return Ok(new SettingsPhotoDto() { FileName = fileName + extension });
            }
            return Ok(new SettingsPhotoDto() { FileName = String.Empty });
        }
    }
}
