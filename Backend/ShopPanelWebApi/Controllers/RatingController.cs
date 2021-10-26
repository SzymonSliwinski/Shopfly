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
    public class RatingController : ControllerBase
    {
        private readonly RatingService _ratingService;
        public RatingController(AppDbContext context)
        {
            _ratingService = new RatingService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Rating>> GetById(int id)
        {
            return Ok(await _ratingService.GetById(id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Rating>> GetAll()
        {
            return Ok(await _ratingService.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Rating>> Delete(int id)
        {
            return Ok(await _ratingService.Delete(id));
        }

        [HttpPost]
        public async Task<ActionResult<Rating>> Add([FromBody] Rating rating)
        {
            return Ok(await _ratingService.Add(rating));
        }

        [HttpPatch]
        public async Task<ActionResult<Rating>> Update([FromBody] Rating rating)
        {
            return Ok(await _ratingService.Update(rating));
        }
    }
}
