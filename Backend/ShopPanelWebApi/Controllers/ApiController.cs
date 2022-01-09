using Common;
using Common.Models.ApiModels;
using Common.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly AppDbContext _context;
        private CrudService<ApiAccessKey> _service;
        public ApiController(AppDbContext context)
        {
            _context = context;
            _service = new CrudService<ApiAccessKey>(_context);
        }

        [HttpPost]
        public async Task<ActionResult<ApiAccessKey>> Add([FromBody] ApiAccessKey apiAccessKey)
        {
            apiAccessKey.Key = apiAccessKey.Key.Trim();
            apiAccessKey.CreateDate = DateTime.Now.ToLocalTime();
            apiAccessKey.IsActive = true;
            return Ok(await _service.Insert(apiAccessKey));
        }
    }
}
