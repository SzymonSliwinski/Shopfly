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
        private readonly AppDbContext _paymentTypeService;
        public PaymentTypeController(AppDbContext context)
        {
            _paymentTypeService = context;
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<PaymentType>> GetById(int id)
        {
            var service = new CrudService<PaymentType>(_paymentTypeService);
            var paymentType = await service.GetById(id);

            return Ok(await service.GetById(paymentType.Id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<PaymentType>> GetAll()
        {
            var service = new CrudService<PaymentType>(_paymentTypeService);
            return Ok(await service.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var service = new CrudService<PaymentType>(_paymentTypeService);
            var paymentType = await service.GetById(id);

            paymentType.IsActive = false;

            await service.Update(paymentType);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<PaymentType>> Add([FromBody] PaymentType paymentType)
        {
            var service = new CrudService<PaymentType>(_paymentTypeService);

            paymentType.Name = paymentType.Name.Trim();
            paymentType.Icon = paymentType.Icon.Trim();
            paymentType.IsActive = true;

            return Ok(await service.Insert(paymentType));
        }

        [HttpPatch]
        public async Task<ActionResult<PaymentType>> Update([FromBody] PaymentType updatedPaymentType)
        {
            var service = new CrudService<PaymentType>(_paymentTypeService);
            var oldPaymentType = await service.GetById(updatedPaymentType.Id);

            oldPaymentType.Name = updatedPaymentType.Name.Trim();
            oldPaymentType.Icon = updatedPaymentType.Icon.Trim();

            return Ok(await service.Update(oldPaymentType));
        }
    }
}
