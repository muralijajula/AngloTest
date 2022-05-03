using AA.CommoditiesDashboard.Domain.Models;
using AA.CommoditiesDashboard.Domain.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Api.Controllers
{
    public class HistoricalTrendsController : BaseController
    {
        private readonly IHistoricalTrendsService _historicalTrendsService;

        public HistoricalTrendsController(IHistoricalTrendsService historicalTrendsService)
        {
            _historicalTrendsService = historicalTrendsService;
        }
        [HttpGet("historical-pnl")]
        [ProducesResponseType(typeof(CommodityPrice), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetHistoricalPnL([FromQuery] MetricType? metricType = MetricType.Yearly)
        {
            var result = await _historicalTrendsService.GetHistoricalPnLAsync(metricType.Value);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("historical-pnl/{commodity}/{date}")]
        [ProducesResponseType(typeof(CommodityPrice), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetHistoricalPnL(string commodity, string date)
        {
            var result = await _historicalTrendsService.GetHistoricalPnLByCommodityAsync(commodity, date);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
