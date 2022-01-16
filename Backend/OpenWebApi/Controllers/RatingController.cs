using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ApiModels;
using Common.Models.ShopModels;
using Common.Services;
using OpenWebApi.Filters;

namespace OpenWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly AppDbContext _ratingService;
        public RatingController(AppDbContext context)
        {
            _ratingService = context;
        }

        [KeyAuthenticationFilter(Table = TableType.ratings, Method = HttpMethodType.get)]
        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Rating>> GetById(int id)
        {
            var service = new CrudService<Rating>(_ratingService);
            var rating = await service.GetById(id);

            return Ok(await service.GetById(rating.Id));
        }

        [KeyAuthenticationFilter(Table = TableType.ratings, Method = HttpMethodType.get)]
        [HttpGet("get-all")]
        public async Task<ActionResult<Rating>> GetAll()
        {
            var service = new CrudService<Rating>(_ratingService);
            return Ok(await service.GetAll());
        }

        [KeyAuthenticationFilter(Table = TableType.ratings, Method = HttpMethodType.delete)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rating>> Delete(int id)
        {
            var service = new CrudService<Rating>(_ratingService);
            await service.Delete(id);

            return Ok();
        }

        [KeyAuthenticationFilter(Table = TableType.ratings, Method = HttpMethodType.post)]
        [HttpPost]
        public async Task<ActionResult<Rating>> Add([FromBody] Rating rating)
        {
            var service = new CrudService<Rating>(_ratingService);

            return Ok(await service.Insert(rating));
        }

        [KeyAuthenticationFilter(Table = TableType.ratings, Method = HttpMethodType.patch)]
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
