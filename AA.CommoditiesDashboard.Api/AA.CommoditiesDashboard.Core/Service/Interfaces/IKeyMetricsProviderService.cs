using AA.CommoditiesDashboard.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Domain.Service.Interfaces
{
    public interface IKeyMetricsProviderService
    {
        Task<IEnumerable<ModelPnl>> GetKeyMetricPnlByModelAsync(MetricType metricType);
        Task<IEnumerable<CommodityPrice>> GetKeyMetricPnlByCommodityAsync(MetricType metricType);
    }
}