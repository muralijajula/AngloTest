using AA.CommoditiesDashboard.Domain.Models;
using AA.CommoditiesDashboard.Domain.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Api.Controllers
{
    public class KeyMetricsController : BaseController
    {
        private readonly IKeyMetricsProviderService _keyMetricsProviderService;

        public KeyMetricsController(IKeyMetricsProviderService keyMetricsProviderService)
        {
            _keyMetricsProviderService = keyMetricsProviderService;
        }

        [HttpGet("commodity-price")]
        [ProducesResponseType(typeof(CommodityPrice), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetKeyMetricPriceByCommodity([FromQuery] MetricType? metricType = MetricType.Monthly)
        {
            var result = await _keyMetricsProviderService.GetKeyMetricPnlByCommodityAsync(metricType.Value);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("model-pnl")]
        [ProducesResponseType(typeof(CommodityPrice), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetKeyMetricPnlByModel([FromQuery] MetricType? metricType = MetricType.Monthly)
        {
            var result = await _keyMetricsProviderService.GetKeyMetricPnlByModelAsync(metricType.Value);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


    }
}
