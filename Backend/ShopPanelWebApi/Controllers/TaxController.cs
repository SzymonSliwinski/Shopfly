using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopModels;
using Common.Services;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    //[TokenAuthenticationFilter]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly AppDbContext _taxService;
        public TaxController(AppDbContext context)
        {
            _taxService = context;
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Tax>> GetById(int id)
        {
            var service = new CrudService<Tax>(_taxService);
            var tax = await service.GetById(id);

            return Ok(await service.GetById(tax.Id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Tax>> GetAll()
        {
            var service = new CrudService<Tax>(_taxService);
            return Ok(await service.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Tax>> Delete(int id)
        {
            var service = new CrudService<Tax>(_taxService);
            var tax = await service.GetById(id);

            await service.Update(tax);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Tax>> Add([FromBody] Tax tax)
        {
            var service = new CrudService<Tax>(_taxService);

            return Ok(await service.Insert(tax));
        }

        [HttpPatch]
        public async Task<ActionResult<Tax>> Update([FromBody] Tax updatedTax)
        {
            var service = new CrudService<Tax>(_taxService);
            var oldTax = await service.GetById(updatedTax.Id);

            oldTax.Name = updatedTax.Name;
            oldTax.Interest = updatedTax.Interest;

            return Ok(await service.Update(oldTax));
        }
    }
}
