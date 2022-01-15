using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ApiModels;
using Common.Models.ShopModels;
using Common.Services;
using OpenWebApi.Filters;

namespace OpenWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        private readonly AppDbContext _paymentTypeService;
        public PaymentTypeController(AppDbContext context)
        {
            _paymentTypeService = context;
        }

        [KeyAuthenticationFilter(Table = TableType.paymentTypes, Method = HttpMethodType.get)]
        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<PaymentType>> GetById(int id)
        {
            var service = new CrudService<PaymentType>(_paymentTypeService);
            var paymentType = await service.GetById(id);

            return Ok(await service.GetById(paymentType.Id));
        }

        [KeyAuthenticationFilter(Table = TableType.paymentTypes, Method = HttpMethodType.get)]
        [HttpGet("get-all")]
        public async Task<ActionResult<PaymentType>> GetAll()
        {
            var service = new CrudService<PaymentType>(_paymentTypeService);
            return Ok(await service.GetAll());
        }

        [KeyAuthenticationFilter(Table = TableType.paymentTypes, Method = HttpMethodType.delete)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var service = new CrudService<PaymentType>(_paymentTypeService);
            var paymentType = await service.GetById(id);

            paymentType.IsActive = false;

            await service.Update(paymentType);
            return Ok();
        }

        [KeyAuthenticationFilter(Table = TableType.paymentTypes, Method = HttpMethodType.post)]
        [HttpPost]
        public async Task<ActionResult<PaymentType>> Add([FromBody] PaymentType paymentType)
        {
            var service = new CrudService<PaymentType>(_paymentTypeService);

            paymentType.Name = paymentType.Name.Trim();
            paymentType.Icon = paymentType.Icon.Trim();
            paymentType.IsActive = true;

            return Ok(await service.Insert(paymentType));
        }

        [KeyAuthenticationFilter(Table = TableType.paymentTypes, Method = HttpMethodType.patch)]
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
