using AA.CommoditiesDashboard.Domain.Models;
using AA.CommoditiesDashboard.Domain.Service.Interfaces;
using AA.CommoditiesDashboard.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Domain.Service
{
    public class KeyMetricsProviderService :  IKeyMetricsProviderService
    {
        private readonly ICommodityDataRepository _commodityDataRepository;

        public KeyMetricsProviderService(ICommodityDataRepository commodityDataRepository)
        {
            _commodityDataRepository = commodityDataRepository;
        }

        public async Task<IEnumerable<CommodityPrice>> GetKeyMetricPnlByCommodityAsync(MetricType metricType)
        {
            var commodityData = await _commodityDataRepository.GetRecentCommodityHistory();
            return mapToCommodityPriceModel(commodityData, metricType);
        }
        
        public async Task<IEnumerable<ModelPnl>> GetKeyMetricPnlByModelAsync(MetricType metricType)
        {
            var commodityData = await _commodityDataRepository.GetRecentCommodityHistory();
            return mapToModelPnlModel(commodityData, metricType);
        }

        private IEnumerable<CommodityPrice> mapToCommodityPriceModel(IEnumerable<Infrastructure.Entities.CommodityData> commodityData, MetricType metricType)
        {
            var commodityPrice = commodityData.GroupBy(x => new { CommodityName = x.Commodity.Name, DateRange = x.Date.ToString(DateFormatHelper.GetDateFormat(metricType)) })
                  .Select(e =>
                      new CommodityPrice(e.Key.CommodityName, e.Key.DateRange, e.ToList().Average(y => y.Price))).ToList();
            return commodityPrice;
        }

        private IEnumerable<ModelPnl> mapToModelPnlModel(IEnumerable<Infrastructure.Entities.CommodityData> commodityData, MetricType metricType)
        {
            var modelPnl = commodityData.GroupBy(x => new { ModelName = x.Commodity.Model.Name, DateRange = x.Date.ToString(DateFormatHelper.GetDateFormat(metricType)) })
                  .Select(e =>
                      new ModelPnl(e.Key.ModelName, e.Key.DateRange, e.ToList().Average(y => y.PnlDaily))).ToList();
            return modelPnl;
        }
    }
}
