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
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        public CustomerController(AppDbContext context)
        {
            _customerService = new CustomerService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Customer>> GetById(int id)
        {
            return Ok(await _customerService.GetById(id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Customer>> GetAll()
        {
            return Ok(await _customerService.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> Delete(int id)
        {
            return Ok(await _customerService.Delete(id));
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Add([FromBody] Customer customer)
        {
            return Ok(await _customerService.Add(customer));
        }

        [HttpPatch]
        public async Task<ActionResult<Customer>> Update([FromBody] Customer customer)
        {
            return Ok(await _customerService.Update(customer));
        }
    }
}
