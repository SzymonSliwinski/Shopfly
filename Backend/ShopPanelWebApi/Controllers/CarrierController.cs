using System.Collections;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopModels;
using Common.Services;
using ShopPanelWebApi.Filters;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    //[TokenAuthenticationFilter]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        private readonly AppDbContext _carrierService;
        public CarrierController(AppDbContext context)
        {
            _carrierService = context;
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Carrier>> GetById(int id)
        {
            var service = new CrudService<Carrier>(_carrierService);
            var carrier = await service.GetById(id);

            return Ok(await service.GetById(carrier.Id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Carrier>> GetAll()
        {
            var service = new CrudService<Carrier>(_carrierService);
            return Ok(await service.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var service = new CrudService<Carrier>(_carrierService);
            var carrier = await service.GetById(id);

            carrier.IsActive = false;

            await service.Update(carrier);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Carrier>> Add([FromBody] Carrier carrier)
        {
            var service = new CrudService<Carrier>(_carrierService);

            carrier.Name = carrier.Name.Trim();
            carrier.IsActive = true;

            return Ok(await service.Insert(carrier));
        }

        [HttpPatch]
        public async Task<ActionResult<Carrier>> Update([FromBody] Carrier updatedCarrier)
        {
            var service = new CrudService<Carrier>(_carrierService);
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
