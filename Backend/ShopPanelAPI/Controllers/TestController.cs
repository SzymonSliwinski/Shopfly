using ShopWebApi.Filters;
using Microsoft.AspNetCore.Mvc;


namespace ShopPanelApi.Controllers
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
