using System;
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
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _customerService;
        public CustomerController(AppDbContext context)
        {
            _customerService = context;
        }

        [KeyAuthenticationFilter(Table = TableType.customers, Method = HttpMethodType.get)]
        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Customer>> GetById(int id)
        {
            var service = new CrudService<Customer>(_customerService);
            var customer = await service.GetById(id);

            return Ok(await service.GetById(customer.Id));
        }

        [KeyAuthenticationFilter(Table = TableType.customers, Method = HttpMethodType.get)]
        [HttpGet("get-all")]
        public async Task<ActionResult<Customer>> GetAll()
        {
            var service = new CrudService<Customer>(_customerService);
            return Ok(await service.GetAll());
        }

        [KeyAuthenticationFilter(Table = TableType.customers, Method = HttpMethodType.delete)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var service = new CrudService<Customer>(_customerService);
            var customer = await service.GetById(id);

            customer.IsActive = false;

            await service.Update(customer);
            return Ok();
        }

        [KeyAuthenticationFilter(Table = TableType.customers, Method = HttpMethodType.post)]
        [HttpPost]
        public async Task<ActionResult<Customer>> Add([FromBody] Customer customer)
        {
            var service = new CrudService<Customer>(_customerService);

            customer.Name = customer.Name.Trim();
            customer.Surname = customer.Surname.Trim();
            customer.PhoneNumber = customer.PhoneNumber.Trim();
            customer.Email = customer.Email.Trim();
            customer.CreateDate = DateTime.Now.ToLocalTime();
            customer.LastLoginDate = DateTime.Now.ToLocalTime();
            customer.Password = customer.Password.Trim();
            customer.IsActive = true;

            return Ok(await service.Insert(customer));
        }

        [KeyAuthenticationFilter(Table = TableType.customers, Method = HttpMethodType.patch)]
        [HttpPatch]
        public async Task<ActionResult<Customer>> Update([FromBody] Customer updatedCustomer)
        {
            var service = new CrudService<Customer>(_customerService);
            var oldCustomer = await service.GetById(updatedCustomer.Id);

            oldCustomer.Name = updatedCustomer.Name.Trim();
            oldCustomer.Surname = updatedCustomer.Surname.Trim();
            oldCustomer.PhoneNumber = updatedCustomer.PhoneNumber.Trim();
            oldCustomer.Email = updatedCustomer.Email.Trim();
            oldCustomer.IsNewsletterSubscribed = updatedCustomer.IsNewsletterSubscribed;
            oldCustomer.LastLoginDate = DateTime.Now.ToLocalTime();

            return Ok(await service.Update(oldCustomer));
        }
    }
}
