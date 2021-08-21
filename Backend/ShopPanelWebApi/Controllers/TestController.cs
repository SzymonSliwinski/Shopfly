using ShopPanelWebApi.Filters;
using Microsoft.AspNetCore.Mvc;


namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
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
