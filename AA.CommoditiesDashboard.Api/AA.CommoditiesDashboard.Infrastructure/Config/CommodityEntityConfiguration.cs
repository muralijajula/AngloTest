using AA.CommoditiesDashboard.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AA.CommoditiesDashboard.Infrastructure.Config
{
    internal class CommodityEntityConfiguration : IEntityTypeConfiguration<Commodity>
    {
        public void Configure(EntityTypeBuilder<Commodity> builder)
        {
            builder.ToTable("Commodity");
            builder.HasKey(x => x.Id);

            //builder.Property(x => x.Id).IsRequired();
            //builder.Property(x => x.Name).IsRequired();

            builder.HasOne(a => a.Model)
                .WithMany()
                .HasForeignKey(x => x.ModelId);
        }
    }
}
