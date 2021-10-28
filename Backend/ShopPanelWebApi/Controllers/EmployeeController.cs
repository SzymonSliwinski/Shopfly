using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopPanelModels;
using Common.Services;
using ShopPanelWebApi.Filters;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    [TokenAuthenticationFilter]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        public EmployeeController(AppDbContext context)
        {
            _employeeService = new EmployeeService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            return Ok(await _employeeService.GetById(id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Employee>> GetAll()
        {
            return Ok(await _employeeService.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            return Ok(await _employeeService.Delete(id));
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Add([FromBody] Employee employee)
        {
            return Ok(await _employeeService.Add(employee));
        }

        [HttpPatch]
        public async Task<ActionResult<Employee>> Update([FromBody] Employee employee)
        {
            return Ok(await _employeeService.Update(employee));
        }
    }
}
