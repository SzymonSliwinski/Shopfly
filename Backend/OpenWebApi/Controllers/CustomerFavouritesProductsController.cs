using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopModels;
using Common.Services;
using Common.Dtos;
using Common.Models.ApiModels;
using OpenWebApi.Filters;

namespace OpenWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerFavouritesProductsController : ControllerBase
    {
        private readonly CustomerFavouritesProductsService _customerFavouritesProductsService;
        public CustomerFavouritesProductsController(AppDbContext context)
        {
            _customerFavouritesProductsService = new CustomerFavouritesProductsService(context);
        }

        [KeyAuthenticationFilter(Table = TableType.customrFavouritesProducts, Method = HttpMethodType.get)]
        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<CustomerFavouritesProducts>> FindOne(int customerId, int productId)
        {
            return Ok(await _customerFavouritesProductsService.FindOne(customerId, productId));
        }

        [KeyAuthenticationFilter(Table = TableType.customrFavouritesProducts, Method = HttpMethodType.delete)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerFavouritesProducts>> Delete(int customerId, int productId)
        {
            return Ok(await _customerFavouritesProductsService.Delete(customerId, productId));
        }

        [KeyAuthenticationFilter(Table = TableType.customrFavouritesProducts, Method = HttpMethodType.post)]
        [HttpPost]
        public async Task<ActionResult<CustomerFavouritesProducts>> Add([FromBody] CustomerFavouritesProducts customerFavouritesProducts)
        {
            return Ok(await _customerFavouritesProductsService.Add(customerFavouritesProducts));
        }

        [KeyAuthenticationFilter(Table = TableType.customrFavouritesProducts, Method = HttpMethodType.patch)]
        [HttpPatch]
        public async Task<ActionResult<CustomerFavouritesProducts>> Update([FromBody] UpdateModelDto<CustomerFavouritesProducts> payload)
        {
            return Ok(await _customerFavouritesProductsService.Update(payload));
        }

        [KeyAuthenticationFilter(Table = TableType.customrFavouritesProducts, Method = HttpMethodType.post)]
        [HttpPost]
        public async Task<ActionResult<CustomerFavouritesProducts>> AddMany([FromBody] List<CustomerFavouritesProducts> customerFavouritesProductsList)
        {
            return Ok(await _customerFavouritesProductsService.AddMany(customerFavouritesProductsList));
        }

        [KeyAuthenticationFilter(Table = TableType.customrFavouritesProducts, Method = HttpMethodType.delete)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerFavouritesProducts>> RemoveMany(List<CustomerFavouritesProducts> customerFavouritesProductsList)
        {
            return Ok(await _customerFavouritesProductsService.RemoveMany(customerFavouritesProductsList));
        }
    }
}
