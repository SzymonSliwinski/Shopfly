using Common.Dtos;
using Common.Interfaces;
using Common.Models.Token;
using ShopPanelWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using ShopPanelWebApi.Filters;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/employees-authentication")]
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
            //to do compare with every request is token expired if expired return 401 and redirect to sign in on front end
            if (_authService.Authenticate(authDto.Email, authDto.Password))
                return Ok(new { Token = _authService.GenerateToken() });
            //todo after generating token get user from db
            else
                return Unauthorized();
        }

        [TokenAuthenticationFilter]
        [Route("logout/{token}")]
        [HttpDelete]
        public IActionResult Logout(string token)
        {
            _authService.RemoveToken(token);
            return Ok();
        }
    }
}
