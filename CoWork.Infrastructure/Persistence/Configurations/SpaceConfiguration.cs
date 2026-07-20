using CoWork.Domain.Spaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Infrastructure.Persistence.Configurations
{
    public class SpaceConfiguration : IEntityTypeConfiguration<Space>
    {
        public void Configure(EntityTypeBuilder<Space> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(30);

            builder.Property(x=>x.BaseCapacity).IsRequired();

            builder.Property(x=>x.BaseDailyPrice).IsRequired();
            builder.Property(x => x.BaseDailyPrice).HasPrecision(18, 2);
        }
    }
}
