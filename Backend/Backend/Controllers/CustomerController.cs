using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopPanelModels;
using Common.Services;
using Common.Utilieties;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Common.Dtos;
using Common.Models.ShopModels;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;
        private CrudService<Customer> _service;
        public CustomerController(AppDbContext context)
        {
            _context = context;
            _service = new CrudService<Customer>(_context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var employee = await _service.GetById(id);
            if (employee != null)
                employee.Password = null;
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Add([FromBody] Customer customer)
        {

            customer.Name = customer.Name.Trim();
            customer.Surname = customer.Surname.Trim();
            customer.Email = customer.Email.Trim();
            customer.IsActive = true;
            customer.Password = customer.Password.Trim();
            customer.Password = Utility.GetHashedPassword(customer.Password);
            customer.CreateDate = DateTime.Now.ToLocalTime();
            customer.IsActive = true;
            var result = await _service.Insert(customer);
            result.Password = null;
            return Ok(result);
        }
    }
}
