using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopModels;
using Common.Services;
using ShopPanelWebApi.Filters;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    [TokenAuthenticationFilter]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly PhotoService _photoService;
        public PhotoController(AppDbContext context)
        {
            _photoService = new PhotoService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Photo>> GetById(int id)
        {
            return Ok(await _photoService.GetById(id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Photo>> GetAll()
        {
            return Ok(await _photoService.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Photo>> Delete(int id)
        {
            return Ok(await _photoService.Delete(id));
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Add([FromBody] Photo photo)
        {
            return Ok(await _photoService.Add(photo));
        }

        [HttpPatch]
        public async Task<ActionResult<Product>> Update([FromBody] Photo photo)
        {
            return Ok(await _photoService.Update(photo));
        }
    }
}
