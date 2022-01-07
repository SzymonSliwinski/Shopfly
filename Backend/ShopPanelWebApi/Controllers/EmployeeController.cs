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

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    //[TokenAuthenticationFilter]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var service = new CrudService<Employee>(_context);
            var employee = await service.GetById(id);
            employee.Password = null;
            return Ok(employee);
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<Employee>>> GetAll()
        {
            var service = new CrudService<Employee>(_context);
            var results = await service.GetAll();
            foreach (var result in results)
                result.Password = null;
            return Ok(results);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var service = new CrudService<Employee>(_context);
            // var employee = await service.GetById(id);
            await service.Delete(id);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Add([FromBody] Employee employee)
        {
            var service = new CrudService<Employee>(_context);

            employee.Name = employee.Name.Trim();
            employee.Surname = employee.Surname.Trim();
            employee.Email = employee.Email.Trim();
            employee.IsActive = true;
            employee.Password = employee.Password.Trim();
            employee.Password = Utility.GetHashedPassword(employee.Password);
            employee.IsRoot = false;

            return Ok(await service.Insert(employee));
        }

        [HttpPatch]
        public async Task<ActionResult<Employee>> Update([FromBody] Employee updatedEmployee)
        {
            var service = new CrudService<Employee>(_context);
            var oldEmployee = await service.GetById(updatedEmployee.Id);

            oldEmployee.Name = updatedEmployee.Name.Trim();
            oldEmployee.Surname = updatedEmployee.Surname.Trim();
            oldEmployee.Email = updatedEmployee.Email.Trim();
            if (!String.IsNullOrEmpty(updatedEmployee.Password))
            {
                oldEmployee.Password = updatedEmployee.Password.Trim();
                oldEmployee.Password = Utility.GetHashedPassword(oldEmployee.Password);
            }
            return Ok(await service.Update(oldEmployee));
        }
    }
}
