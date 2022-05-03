using AA.CommoditiesDashboard.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.Domain.Service.Interfaces
{
    public interface ICommodityProviderService
    {
        Task<IEnumerable<CommodityRecentHistory>> GetRecentHistoryAsync(int? noofDays = null);
    }
}
