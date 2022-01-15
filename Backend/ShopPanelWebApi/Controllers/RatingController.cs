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
        private readonly AppDbContext _ratingService;
        public RatingController(AppDbContext context)
        {
            _ratingService = context;
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Rating>> GetById(int id)
        {
            var service = new CrudService<Rating>(_ratingService);
            var rating = await service.GetById(id);

            return Ok(await service.GetById(rating.Id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Rating>> GetAll()
        {
            var service = new CrudService<Rating>(_ratingService);
            return Ok(await service.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Rating>> Delete(int id)
        {
            var service = new CrudService<Rating>(_ratingService);
            await service.Delete(id);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Rating>> Add([FromBody] Rating rating)
        {
            var service = new CrudService<Rating>(_ratingService);

            return Ok(await service.Insert(rating));
        }

        [HttpPatch]
        public async Task<ActionResult<Rating>> Update([FromBody] Rating updatedRating)
        {
            var service = new CrudService<Rating>(_ratingService);
            var oldRating = await service.GetById(updatedRating.Id);

            oldRating.Rate = updatedRating.Rate;

            return Ok(await service.Update(oldRating));
        }
    }
}
