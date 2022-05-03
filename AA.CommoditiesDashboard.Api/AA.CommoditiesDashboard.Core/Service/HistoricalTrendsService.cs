using AA.CommoditiesDashboard.Domain.Models;
using AA.CommoditiesDashboard.Domain.Service.Interfaces;
using AA.CommoditiesDashboard.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Domain.Service
{
    public class HistoricalTrendsService : IHistoricalTrendsService
    {
        private readonly ICommodityDataRepository _commodityDataRepository;
        public HistoricalTrendsService(ICommodityDataRepository commodityDataRepository)
        {
            _commodityDataRepository = commodityDataRepository;
        }
        public async Task<IEnumerable<HistoricalPnl>> GetHistoricalPnLAsync(MetricType metricType)
        {
            var commodityData = await _commodityDataRepository.GetRecentCommodityHistory(null);
            return mapToHistoricalPnllModel(commodityData, metricType);
        }
        public async Task<IEnumerable<HistoricalPnl>> GetHistoricalPnLByCommodityAsync(string commodity, string date)
        {
            var commodityData = await _commodityDataRepository.GetRecentCommodityHistory(null);
            var data = commodityData.Where(x => x.Commodity.Name.ToLower() == commodity.ToLower() && x.Date.ToString("yyyy") == date).ToList();
            return mapToHistoricalPnllModel(data, MetricType.Daily);
        }

        private IEnumerable<HistoricalPnl> mapToHistoricalPnllModel(IEnumerable<Infrastructure.Entities.CommodityData> commodityData, MetricType dateRange)
        {
            var commodityPrice = commodityData.GroupBy(x => new { CommodityName = x.Commodity.Name, DateRange = x.Date.ToString(DateFormatHelper.GetDateFormat(dateRange)) })
                  .Select(e =>
                      new HistoricalPnl(e.Key.DateRange, e.ToList().Sum(y => y.PnlDaily)
                      , e.Key.CommodityName)).ToList();
            return commodityPrice;
        }
    }
}