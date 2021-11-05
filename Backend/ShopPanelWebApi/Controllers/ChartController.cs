using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Common.Dtos;
using ShopPanelWebApi.Filters;
using ShopPanelWebApi.Services;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    [TokenAuthenticationFilter]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly ChartsService _chartsService;
        public ChartController(AppDbContext context)
        {
            _chartsService = new ChartsService(context);
        }
        
        [HttpPost("order-chart-data")]
        public async Task<ActionResult<Dictionary<DateTime, int>>> GetOrderChartData([FromBody] DataRangeDto dataRange)
        {
            return Ok(await _chartsService.GetOrdersChartDataFromDays(dataRange.From, dataRange.To));
        }

    }
}
