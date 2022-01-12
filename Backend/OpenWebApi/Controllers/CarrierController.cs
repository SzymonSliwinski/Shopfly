using System.Collections;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopModels;
using Common.Services;
using OpenWebApi.Filters;
using Common.Models.ApiModels;
namespace ShopPanelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CarrierController(AppDbContext context)
        {
            _context = context;
        }
        [KeyAuthenticationFilter(Table = TableType.carriers, Method = HttpMethodType.get)]
        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Carrier>> GetById(int id)
        {
            var service = new CrudService<Carrier>(_context);
            var carrier = await service.GetById(id);

            return Ok(await service.GetById(carrier.Id));
        }

        [KeyAuthenticationFilter(Table = TableType.carriers, Method = HttpMethodType.get)]
        [HttpGet("get-all")]
        public async Task<ActionResult<Carrier>> GetAll()
        {
            var service = new CrudService<Carrier>(_context);
            return Ok(await service.GetAll());
        }

        [KeyAuthenticationFilter(Table = TableType.carriers, Method = HttpMethodType.delete)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var service = new CrudService<Carrier>(_context);
            var carrier = await service.GetById(id);

            carrier.IsActive = false;

            await service.Update(carrier);
            return Ok();
        }

        [KeyAuthenticationFilter(Table = TableType.carriers, Method = HttpMethodType.post)]
        [HttpPost]
        public async Task<ActionResult<Carrier>> Add([FromBody] Carrier carrier)
        {
            var service = new CrudService<Carrier>(_context);

            carrier.Name = carrier.Name.Trim();
            carrier.IsActive = true;

            return Ok(await service.Insert(carrier));
        }

        [KeyAuthenticationFilter(Table = TableType.carriers, Method = HttpMethodType.patch)]
        [HttpPatch]
        public async Task<ActionResult<Carrier>> Update([FromBody] Carrier updatedCarrier)
        {
            var service = new CrudService<Carrier>(_context);
            var oldCarrier = await service.GetById(updatedCarrier.Id);

            oldCarrier.Cost = updatedCarrier.Cost;
            oldCarrier.Name = updatedCarrier.Name.Trim();
            oldCarrier.Logo = updatedCarrier.Logo;
            oldCarrier.DeliveryDaysMinimum = updatedCarrier.DeliveryDaysMinimum;
            oldCarrier.DeliveryDaysMaximum = updatedCarrier.DeliveryDaysMaximum;

            return Ok(await service.Update(oldCarrier));
        }
    }
}
