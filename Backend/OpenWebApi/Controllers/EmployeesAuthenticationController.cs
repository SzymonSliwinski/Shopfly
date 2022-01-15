using Common;
using Common.Dtos;
using Common.Interfaces;
using Common.Utilieties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace OpenWebApi.Controllers
{
    [Route("api/employees-authentication")]
    [ApiController]
    public class EmployeesAuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        private readonly AppDbContext _context;

        public EmployeesAuthenticationController(IAuthenticationService authService, AppDbContext context)
        {
            _authService = authService;
            _context = context;
        }
        //todo sprawdzić tutaj
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationDto authDto)
        {
            var hashedPass = Utility.GetHashedPassword(authDto.Password);
            var employee = await _context.Employees
                .AsQueryable()
                .SingleOrDefaultAsync(e => e.Email == authDto.Email);

            if (employee == null)
                return Unauthorized();

            if (employee.Password == hashedPass)
            {
                var token = new { Token = _authService.GenerateToken() };
                token.Token.UserId = employee.Id;
                return Ok(token);
            }
            else
                return Unauthorized();
        }

        [Route("logout/{token}")]
        [HttpDelete]
        public IActionResult Logout(string token)
        {
            _authService.RemoveToken(token);
            return Ok();
        }
    }
}
