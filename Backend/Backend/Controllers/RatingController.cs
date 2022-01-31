using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopModels;
using Common.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly AppDbContext _context;
        public RatingController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Rating>> Add([FromBody] Rating rating)
        {
            var db = await _context.Ratings.Where(c => c.CustomerId == rating.CustomerId).SingleOrDefaultAsync();
            if (db == null)
            {
                await _context.AddAsync(rating);
                await _context.SaveChangesAsync();
                return Ok(rating);
            }

            db.Rate = rating.Rate;
            await _context.SaveChangesAsync();
            return Ok(rating);
        }
    }
}
