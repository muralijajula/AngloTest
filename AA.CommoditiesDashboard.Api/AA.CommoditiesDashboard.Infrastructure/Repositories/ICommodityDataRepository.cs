using AA.CommoditiesDashboard.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Infrastructure.Repositories
{
    public interface ICommodityDataRepository
    {
        Task<IEnumerable<CommodityData>> GetRecentCommodityHistory(int? noofDays = null);
    }
}