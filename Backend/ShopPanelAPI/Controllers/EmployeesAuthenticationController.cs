using Common.Dtos;
using Common.Interfaces;
using ShopPanelWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

namespace ShopWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
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
