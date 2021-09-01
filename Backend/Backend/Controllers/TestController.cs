using ShopWebApi.Filters;
using Microsoft.AspNetCore.Mvc;


namespace ShopWebApi.Controllers
{
    [Route("[controller]")]
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
