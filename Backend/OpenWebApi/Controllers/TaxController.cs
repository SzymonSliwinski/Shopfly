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
    public class TaxController : ControllerBase
    {
        private readonly AppDbContext _taxService;
        public TaxController(AppDbContext context)
        {
            _taxService = context;
        }

        [KeyAuthenticationFilter(Table = TableType.taxes, Method = HttpMethodType.get)]
        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Tax>> GetById(int id)
        {
            var service = new CrudService<Tax>(_taxService);
            var tax = await service.GetById(id);

            return Ok(await service.GetById(tax.Id));
        }

        [KeyAuthenticationFilter(Table = TableType.taxes, Method = HttpMethodType.get)]
        [HttpGet("get-all")]
        public async Task<ActionResult<Tax>> GetAll()
        {
            var service = new CrudService<Tax>(_taxService);
            return Ok(await service.GetAll());
        }

        [KeyAuthenticationFilter(Table = TableType.taxes, Method = HttpMethodType.delete)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tax>> Delete(int id)
        {
            var service = new CrudService<Tax>(_taxService);
            await service.Delete(id);

            return Ok();
        }

        [KeyAuthenticationFilter(Table = TableType.taxes, Method = HttpMethodType.post)]
        [HttpPost]
        public async Task<ActionResult<Tax>> Add([FromBody] Tax tax)
        {
            var service = new CrudService<Tax>(_taxService);

            tax.Name = tax.Name.Trim();

            return Ok(await service.Insert(tax));
        }

        [KeyAuthenticationFilter(Table = TableType.taxes, Method = HttpMethodType.patch)]
        [HttpPatch]
        public async Task<ActionResult<Tax>> Update([FromBody] Tax updatedTax)
        {
            var service = new CrudService<Tax>(_taxService);
            var oldTax = await service.GetById(updatedTax.Id);

            oldTax.Name = updatedTax.Name.Trim();
            oldTax.Interest = updatedTax.Interest;

            return Ok(await service.Update(oldTax));
        }
    }
}
