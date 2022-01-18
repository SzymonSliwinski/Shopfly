using Common;
using Common.Dtos;
using Common.Interfaces;
using Common.Utilieties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopWebApi.Filters;
using System;
using System.Threading.Tasks;

namespace ShopWebApi.Controllers
{
    [Route("customers-authentication")]
    [ApiController]
    public class CustomersAuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        private AppDbContext _context;

        public CustomersAuthenticationController(IAuthenticationService authService, AppDbContext context)
        {
            _authService = authService;
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationDto authDto)
        {
            var hashedPass = Utility.GetHashedPassword(authDto.Password);
            var customer = await _context.Customers
                .AsQueryable()
                .SingleOrDefaultAsync(e => e.Email == authDto.Email);

            if (customer == null)
                return Unauthorized();

            if (customer.Password == hashedPass)
            {
                var token = new { Token = _authService.GenerateToken() };
                token.Token.UserId = customer.Id;
                customer.LastLoginDate = DateTime.Now.ToLocalTime();
                await _context.SaveChangesAsync();
                return Ok(token);
            }
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
