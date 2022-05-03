using AA.CommoditiesDashboard.Domain.Models;
using AA.CommoditiesDashboard.Domain.Service.Interfaces;
using AA.CommoditiesDashboard.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Domain.Service
{
    public class CommodityProviderService : ICommodityProviderService
    {
        private readonly ICommodityDataRepository _commodityDataRepository;

        public CommodityProviderService(ICommodityDataRepository commodityDataRepository)
        {
            _commodityDataRepository = commodityDataRepository;
        }

        public async Task<IEnumerable<CommodityRecentHistory>> GetRecentHistoryAsync(int? noofdays = null)
        {
            var commodityData = await _commodityDataRepository.GetRecentCommodityHistory(noofdays);
            return mapToCommodityRecentHistory(commodityData);
        }

        private IEnumerable<CommodityRecentHistory> mapToCommodityRecentHistory(IEnumerable<Infrastructure.Entities.CommodityData> commodityData)
        {
            var commodityRecentHistories = commodityData.GroupBy(x => new { CommodityName = x.Commodity.Name, ModelName = x.Commodity.Model.Name })
                  .Select(e => new CommodityRecentHistory(e.Key.CommodityName, e.Key.ModelName,
                                e.ToList().Select(e => new CommodityData(e.Price, e.Position, e.NewTradeAction, e.PnlDaily, e.Date)))).ToList();

            return commodityRecentHistories;
        }
    }
}
