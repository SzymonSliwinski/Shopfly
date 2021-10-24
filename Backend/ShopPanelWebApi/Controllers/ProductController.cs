using Common;
using Common.Models.ShopModels;
using Common.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopPanelWebApi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    [TokenAuthenticationFilter]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(AppDbContext context)
        {
            _productService = new ProductService(context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            return Ok(await _productService.GetById(id));
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<Product>> GetAll()
        {
            return Ok(await _productService.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            return Ok(await _productService.Delete(id));
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Add([FromBody] Product product)
        {
            return Ok(await _productService.Add(product));
        }

        [HttpPatch]
        public async Task<ActionResult<Product>> Update([FromBody] Product product)
        {
            return Ok(await _productService.Update(product));
        }
    }
}
