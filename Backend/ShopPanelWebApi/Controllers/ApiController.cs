using Common;
using Common.Models.ApiModels;
using Common.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public async Task<ActionResult<List<ApiAccessKey>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("does-key-exist/{key}")]
        public async Task<ActionResult<bool>> DoesKeyExist(string key)
        {
            var keyDb = await _context.ApiAccessKeys.AsQueryable().Where(c => c.Key == key).SingleOrDefaultAsync();
            var result = keyDb == null ? false : true;

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var employeeTablesMethodForKey =
                await _context.ApiKeysTablesMethods.Where(c => c.ApiAccessKeyId == id).ToListAsync();
            _context.ApiKeysTablesMethods.RemoveRange(employeeTablesMethodForKey);
            await _service.Delete(id);
            return Ok();
        }
    }
}
