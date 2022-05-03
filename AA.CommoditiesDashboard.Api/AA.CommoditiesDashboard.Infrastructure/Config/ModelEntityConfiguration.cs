using AA.CommoditiesDashboard.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AA.CommoditiesDashboard.Infrastructure.Config
{
    internal class ModelEntityConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.ToTable("Model");
            builder.HasKey(x => x.Id);

        }
    }
}

