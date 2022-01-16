using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopPanelModels;
using Common.Services;
using ShopPanelWebApi.Filters;
using Common.Utilieties;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Common.Dtos;
using Common.Models.ShopModels;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/home-lists")]
    [TokenAuthenticationFilter]
    [ApiController]
    public class ShopListsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private CrudService<HomeList> _service;
        public ShopListsController(AppDbContext context)
        {
            _context = context;
            _service = new CrudService<HomeList>(_context);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<HomeList>> GetById(int id)
        {
            var employee = await _service.GetById(id);
            return Ok(employee);
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<HomeList>>> GetAll()
        {
            var results = await _service.GetAll();
            return Ok(results);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<HomeList>> Add([FromBody] HomeList homeList)
        {

            homeList.Title = homeList.Title.Trim();
            foreach (var homeListProd in homeList.HomeProductsLists)
                homeListProd.HomeList = homeList;
            return Ok(await _service.Insert(homeList));
        }

        [HttpPatch]
        public async Task<ActionResult<HomeList>> Update([FromBody] HomeList homeList)
        {
            var oldEmployee = await _service.GetById(homeList.Id);
            var oldLists = _context.HomeLists
                .AsQueryable()
                .Include(c => c.HomeProductsLists)
                .Where(c => c.Id == homeList.Id)
                .SingleAsync();
            homeList.Title = homeList.Title.Trim();
            homeList.HomeProductsLists = homeList.HomeProductsLists;

            return Ok(await _service.Update(homeList));
        }
    }
}
