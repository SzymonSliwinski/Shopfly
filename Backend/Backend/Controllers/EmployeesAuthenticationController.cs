using Backend.Dtos;
using Backend.Interfaces;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
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
