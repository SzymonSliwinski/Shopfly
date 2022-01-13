using System.Collections;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopModels;
using Common.Services;
using ShopPanelWebApi.Filters;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
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

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Carrier>> GetById(int id)
        {
            var carrier = await _service.GetById(id);

            return Ok(await _service.GetById(carrier.Id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Carrier>> GetAll()
        {
            return Ok(await _context.Carriers.AsQueryable().Where(c => c.IsActive).ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var carrier = await _service.GetById(id);

            carrier.IsActive = false;

            await _service.Update(carrier);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Carrier>> Add([FromBody] Carrier carrier)
        {
            carrier.Name = carrier.Name.Trim();
            carrier.IsActive = true;

            return Ok(await _service.Insert(carrier));
        }

        [HttpPatch]
        public async Task<ActionResult<Carrier>> Update([FromBody] Carrier updatedCarrier)
        {
            var oldCarrier = await _service.GetById(updatedCarrier.Id);

            oldCarrier.Cost = updatedCarrier.Cost;
            oldCarrier.Name = updatedCarrier.Name.Trim();
            oldCarrier.Logo = updatedCarrier.Logo;
            oldCarrier.DeliveryDaysMinimum = updatedCarrier.DeliveryDaysMinimum;
            oldCarrier.DeliveryDaysMaximum = updatedCarrier.DeliveryDaysMaximum;

            return Ok(await _service.Update(oldCarrier));
        }
    }
}
