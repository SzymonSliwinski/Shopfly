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
    public class PaymentTypeController : ControllerBase
    {
        private readonly PaymentTypeService _paymentTypeService;
        public PaymentTypeController(AppDbContext context)
        {
            _paymentTypeService = new PaymentTypeService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<PaymentType>> GetById(int id)
        {
            return Ok(await _paymentTypeService.GetById(id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<PaymentType>> GetAll()
        {
            return Ok(await _paymentTypeService.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentType>> Delete(int id)
        {
            return Ok(await _paymentTypeService.Delete(id));
        }

        [HttpPost]
        public async Task<ActionResult<PaymentType>> Add([FromBody] PaymentType paymentType)
        {
            return Ok(await _paymentTypeService.Add(paymentType));
        }

        [HttpPatch]
        public async Task<ActionResult<PaymentType>> Update([FromBody] PaymentType paymentType)
        {
            return Ok(await _paymentTypeService.Update(paymentType));
        }
    }
}
