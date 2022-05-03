using AA.CommoditiesDashboard.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AA.CommoditiesDashboard.Infrastructure.Tests
{
    public class InMemoryDbContextFactory
    {
        public static CommoditiesDashboardDbContext GetCommoditiesDashboardDbContext()
        {
            var options = new DbContextOptionsBuilder<CommoditiesDashboardDbContext>()
                .UseInMemoryDatabase(databaseName: "CommoditiesDashboardDb")
                .Options;
            return new CommoditiesDashboardDbContext(options);
        }

    }
}
