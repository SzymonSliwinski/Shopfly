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
    public class TaxController : ControllerBase
    {
        private readonly TaxService _taxService;
        public TaxController(AppDbContext context)
        {
            _taxService = new TaxService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Tax>> GetById(int id)
        {
            return Ok(await _taxService.GetById(id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Tax>> GetAll()
        {
            return Ok(await _taxService.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Tax>> Delete(int id)
        {
            return Ok(await _taxService.Delete(id));
        }

        [HttpPost]
        public async Task<ActionResult<Tax>> Add([FromBody] Tax tax)
        {
            return Ok(await _taxService.Add(tax));
        }

        [HttpPatch]
        public async Task<ActionResult<Tax>> Update([FromBody] Tax tax)
        {
            return Ok(await _taxService.Update(tax));
        }
    }
}
