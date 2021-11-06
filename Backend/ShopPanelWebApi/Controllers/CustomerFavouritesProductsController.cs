using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopModels;
using Common.Services;
using ShopPanelWebApi.Filters;
using Common.Dtos;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    [TokenAuthenticationFilter]
    [ApiController]
    public class CustomerFavouritesProductsController : ControllerBase
    {
        private readonly CustomerFavouritesProductsService _customerFavouritesProductsService;
        public CustomerFavouritesProductsController(AppDbContext context)
        {
            _customerFavouritesProductsService = new CustomerFavouritesProductsService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<CustomerFavouritesProducts>> FindOne(int customerId, int productId)
        {
            return Ok(await _customerFavouritesProductsService.FindOne(customerId, productId));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerFavouritesProducts>> Delete(int customerId, int productId)
        {
            return Ok(await _customerFavouritesProductsService.Delete(customerId, productId));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerFavouritesProducts>> Add([FromBody] CustomerFavouritesProducts customerFavouritesProducts)
        {
            return Ok(await _customerFavouritesProductsService.Add(customerFavouritesProducts));
        }

        [HttpPatch]
        public async Task<ActionResult<CustomerFavouritesProducts>> Update([FromBody] UpdateModelDto<CustomerFavouritesProducts> payload)
        {
            return Ok(await _customerFavouritesProductsService.Update(payload));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerFavouritesProducts>> AddMany([FromBody] List<CustomerFavouritesProducts> customerFavouritesProductsList)
        {
            return Ok(await _customerFavouritesProductsService.AddMany(customerFavouritesProductsList));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerFavouritesProducts>> RemoveMany(List<CustomerFavouritesProducts> customerFavouritesProductsList)
        {
            return Ok(await _customerFavouritesProductsService.RemoveMany(customerFavouritesProductsList));
        }
    }
}
