using AA.CommoditiesDashboard.Domain.Models;
using AA.CommoditiesDashboard.Domain.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Api.Controllers
{
    public class CommoditiesController : BaseController
    {
        private readonly ICommodityProviderService _commodityProviderService;
        public CommoditiesController(ICommodityProviderService commodityProviderService)
        {
            _commodityProviderService = commodityProviderService;
        }

        [HttpGet("recent-history")]
        [ProducesResponseType(typeof(IEnumerable<CommodityRecentHistory>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRecentCommodityHistory([FromQuery]int? noofDays)
        {
            var result = await _commodityProviderService.GetRecentHistoryAsync(noofDays);

            if(result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
