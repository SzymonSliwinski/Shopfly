using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopModels;
using Common.Services;
using ShopPanelWebApi.Filters;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    [TokenAuthenticationFilter]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        private readonly CarrierService _carrierService;
        public CarrierController(AppDbContext context)
        {
            _carrierService = new CarrierService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Carrier>> GetById(int id)
        {
            return Ok(await _carrierService.GetById(id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Carrier>> GetAll()
        {
            return Ok(await _carrierService.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Carrier>> Delete(int id)
        {
            return Ok(await _carrierService.Delete(id));
        }

        [HttpPost]
        public async Task<ActionResult<Carrier>> Add([FromBody] Carrier carrier)
        {
            return Ok(await _carrierService.Add(carrier));
        }

        [HttpPatch]
        public async Task<ActionResult<Carrier>> Update([FromBody] Carrier carrier)
        {
            return Ok(await _carrierService.Update(carrier));
        }
    }
}
