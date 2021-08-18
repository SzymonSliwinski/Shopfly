using Common.Dtos;
using ShopWebApi.Interfaces;
using Common.Models;
using ShopWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ShopWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesAuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        public EmployeesAuthenticationController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthenticationDto authDto)
        {
            if (_authService.Authenticate(authDto.LoginOrEmail, authDto.Password))
                return Ok(new { Token = _authService.GenerateToken() });
            //todo after generating token get user from db
            else
                return Unauthorized();
        }
    }
}
