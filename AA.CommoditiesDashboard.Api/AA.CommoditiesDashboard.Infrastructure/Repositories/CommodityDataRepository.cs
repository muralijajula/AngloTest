using AA.CommoditiesDashboard.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System;
using AA.CommoditiesDashboard.Infrastructure.Entities;

namespace AA.CommoditiesDashboard.Infrastructure.Repositories
{
    public class CommodityDataRepository : ICommodityDataRepository
    {
        private readonly CommoditiesDashboardDbContext _commoditiesDashboarddbContext;

        public CommodityDataRepository(CommoditiesDashboardDbContext commoditiesDashboarddbContext)
        {
            _commoditiesDashboarddbContext = commoditiesDashboarddbContext;
        }

        public async Task<IEnumerable<CommodityData>> GetRecentCommodityHistory(int? noofDays = null)
        {
            var maxDate = await _commoditiesDashboarddbContext.CommoditiesData.MaxAsync(x => x.Date);

            var query = _commoditiesDashboarddbContext.CommoditiesData
                .Include("Commodity").Include("Commodity.Model");

            if (noofDays != null)
            {
                query = query.Where(x => x.Date > maxDate.AddDays(-(noofDays.Value)) && x.Date <= maxDate);
            }

            return await query.ToListAsync();

        }


    }
}
