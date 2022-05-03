using AA.CommoditiesDashboard.Infrastructure.Config;
using AA.CommoditiesDashboard.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace AA.CommoditiesDashboard.Infrastructure.Data.Contexts
{
    public class CommoditiesDashboardDbContext : DbContext
    {
        public CommoditiesDashboardDbContext(DbContextOptions<CommoditiesDashboardDbContext> options)
           : base(options)
        {
        }

        internal virtual DbSet<Commodity> Commodities { get; set; }
        internal virtual DbSet<CommodityData> CommoditiesData { get; set; }
        internal virtual DbSet<Model> Models { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CommodityEntityConfiguration());
            builder.ApplyConfiguration(new CommodityDataEntityConfiguration());
            builder.ApplyConfiguration(new ModelEntityConfiguration());

        }

    }
}
