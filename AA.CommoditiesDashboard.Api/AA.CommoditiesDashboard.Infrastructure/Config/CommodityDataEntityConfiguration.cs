using AA.CommoditiesDashboard.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AA.CommoditiesDashboard.Infrastructure.Config
{
    internal class CommodityDataEntityConfiguration : IEntityTypeConfiguration<CommodityData>
    {
        public void Configure(EntityTypeBuilder<CommodityData> builder)
        {
            builder.ToTable("CommodityData");
            builder.HasKey(x => x.Id);

            //builder.Property(x => x.Id).IsRequired();
            //builder.Property(x => x.Contract).IsRequired();
            //builder.Property(x => x.Date).IsRequired();
            //builder.Property(x => x.Price).IsRequired();
            //builder.Property(x => x.Position).IsRequired();
            //builder.Property(x => x.NewTradeAction).IsRequired();
            //builder.Property(x => x.PnlDaily).IsRequired();


            builder.HasOne(a => a.Commodity)
                .WithMany()
                .HasForeignKey(x => x.CommodityId);
        }
    }
}
