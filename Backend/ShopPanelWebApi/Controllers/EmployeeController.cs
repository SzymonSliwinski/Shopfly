using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopPanelModels;
using Common.Services;
using ShopPanelWebApi.Filters;
using Common.Utilieties;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Common.Dtos;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    //[TokenAuthenticationFilter]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;
        private CrudService<Employee> _service;
        public EmployeeController(AppDbContext context)
        {
            _context = context;
            _service = new CrudService<Employee>(_context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var employee = await _service.GetById(id);

            employee.Password = null;
            return Ok(employee);
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<Employee>>> GetAll()
        {
            var results = await _service.GetAll();
            foreach (var result in results)
                result.Password = null;
            return Ok(results);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Add([FromBody] Employee employee)
        {

            employee.Name = employee.Name.Trim();
            employee.Surname = employee.Surname.Trim();
            employee.Email = employee.Email.Trim();
            employee.IsActive = true;
            employee.Password = employee.Password.Trim();
            employee.Password = Utility.GetHashedPassword(employee.Password);
            employee.IsRoot = false;

            return Ok(await _service.Insert(employee));
        }

        [HttpPatch]
        public async Task<ActionResult<Employee>> Update([FromBody] Employee updatedEmployee)
        {
            var oldEmployee = await _service.GetById(updatedEmployee.Id);

            oldEmployee.Name = updatedEmployee.Name.Trim();
            oldEmployee.Surname = updatedEmployee.Surname.Trim();
            oldEmployee.Email = updatedEmployee.Email.Trim();
            if (!String.IsNullOrEmpty(updatedEmployee.Password))
            {
                oldEmployee.Password = updatedEmployee.Password.Trim();
                oldEmployee.Password = Utility.GetHashedPassword(oldEmployee.Password);
            }
            return Ok(await _service.Update(oldEmployee));
        }


        [HttpPatch("change-password")]
        public async Task ChangePassword([FromBody] ChangePasswordDto payload)
        {
            var employee = await _service.GetById(payload.UserId);

            employee.Password = Utility.GetHashedPassword(payload.NewPassword);
            await _service.Update(employee);
        }
    }
}
