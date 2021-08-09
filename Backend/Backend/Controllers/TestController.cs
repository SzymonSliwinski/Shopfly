using Backend.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TokenAuthenticationFilter]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> TestAuthentication()
        {
            return Ok("Hello world");
        }
    }
}
