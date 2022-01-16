using System.Collections;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopModels;
using Common.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ShopWebApi.Controllers
{
    [Route("shop/[controller]")]
    //[TokenAuthenticationFilter]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        private readonly AppDbContext _context;
        private CrudService<Carrier> _service;
        public CarrierController(AppDbContext context)
        {
            _context = context;
            _service = new CrudService<Carrier>(_context);
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Carrier>> GetAll()
        {
            return Ok(await _context.Carriers.AsQueryable().Where(c => c.IsActive).ToListAsync());
        }

    }
}
