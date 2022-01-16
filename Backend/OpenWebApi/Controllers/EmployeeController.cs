using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopPanelModels;
using Common.Services;
using Common.Utilieties;
using System.Collections.Generic;
using System;
using Common.Dtos;
using Common.Models.ApiModels;
using OpenWebApi.Filters;

namespace OpenWebApi.Controllers
{
    [Route("api/[controller]")]
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

        [KeyAuthenticationFilter(Table = TableType.employees, Method = HttpMethodType.get)]
        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var employee = await _service.GetById(id);
            employee.Password = null;
            return Ok(employee);
        }

        [KeyAuthenticationFilter(Table = TableType.employees, Method = HttpMethodType.get)]
        [HttpGet("get-all")]
        public async Task<ActionResult<List<Employee>>> GetAll()
        {
            var results = await _service.GetAll();
            foreach (var result in results)
                result.Password = null;
            return Ok(results);
        }

        [KeyAuthenticationFilter(Table = TableType.employees, Method = HttpMethodType.delete)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }

        [KeyAuthenticationFilter(Table = TableType.employees, Method = HttpMethodType.post)]
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

        [KeyAuthenticationFilter(Table = TableType.employees, Method = HttpMethodType.patch)]
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


        [KeyAuthenticationFilter(Table = TableType.employees, Method = HttpMethodType.patch)]
        [HttpPatch("change-password")]
        public async Task ChangePassword([FromBody] ChangePasswordDto payload)
        {
            var employee = await _service.GetById(payload.UserId);

            employee.Password = Utility.GetHashedPassword(payload.NewPassword);
            await _service.Update(employee);
        }
    }
}
