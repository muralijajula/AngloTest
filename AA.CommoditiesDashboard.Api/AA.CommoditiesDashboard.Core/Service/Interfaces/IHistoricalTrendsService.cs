using AA.CommoditiesDashboard.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Domain.Service.Interfaces
{
    public interface IHistoricalTrendsService
    {
        Task<IEnumerable<HistoricalPnl>> GetHistoricalPnLAsync(MetricType value);
        Task<IEnumerable<HistoricalPnl>> GetHistoricalPnLByCommodityAsync(string commodity, string date);

    }
}
