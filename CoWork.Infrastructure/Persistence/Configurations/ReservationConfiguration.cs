using CoWork.Domain.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Infrastructure.Persistence.Configurations
{
    public class ReservationConfiguration:IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(x => x.FinalPrice).HasPrecision(18, 2);
            builder.Property(x=>x.TotalPrice).HasPrecision(18, 2);
        }
    }
}
