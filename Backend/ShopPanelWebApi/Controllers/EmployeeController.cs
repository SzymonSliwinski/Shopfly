using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopPanelModels;
using Common.Services;
using ShopPanelWebApi.Filters;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    //[TokenAuthenticationFilter]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _employeeService;
        public EmployeeController(AppDbContext context)
        {
            _employeeService = context;
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var service = new CrudService<Employee>(_employeeService);
            var employee = await service.GetById(id);

            return Ok(await service.GetById(employee.Id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Employee>> GetAll()
        {
            var service = new CrudService<Employee>(_employeeService);
            return Ok(await service.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var service = new CrudService<Employee>(_employeeService);
            var employee = await service.GetById(id);

            employee.IsActive = false;

            await service.Update(employee);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Add([FromBody] Employee employee)
        {
            var service = new CrudService<Employee>(_employeeService);

            employee.Name = employee.Name.Trim();
            employee.Surname = employee.Surname.Trim();
            employee.Email = employee.Email.Trim();
            employee.IsActive = true;
            employee.Password = employee.Password.Trim();

            return Ok(await service.Insert(employee));
        }

        [HttpPatch]
        public async Task<ActionResult<Employee>> Update([FromBody] Employee updatedEmployee)
        {
            var service = new CrudService<Employee>(_employeeService);
            var oldEmployee = await service.GetById(updatedEmployee.Id);

            oldEmployee.Name = updatedEmployee.Name.Trim();
            oldEmployee.Surname = updatedEmployee.Surname.Trim();
            oldEmployee.Email = updatedEmployee.Email.Trim();

            return Ok(await service.Update(oldEmployee));
        }
    }
}
