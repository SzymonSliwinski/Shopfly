using Common.Dtos;
using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ShopWebApi.Filters;

namespace ShopWebApi.Controllers
{
    [Route("customers-authentication")]
    [ApiController]
    public class CustomersAuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        public CustomersAuthenticationController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthenticationDto authDto)
        {
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
