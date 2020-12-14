using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TruckTest.Domain.Entities;
using TruckTest.Domain.Entities.Enum;

namespace TruckTest.Domain.Mapping
{
    public class TruckMap : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.ToTable("Trucks");

            builder.Property(x => x.Model).IsUnicode(false).HasMaxLength(250);
            builder.Property(x => x.Model)
                   .HasMaxLength(10)
                   .HasConversion(y => y.ToString(), y => (TruckModel)Enum.Parse(typeof(TruckModel), y))
                   .IsUnicode(false);

            builder.Property(x => x.YearFactory).IsRequired();
            builder.Property(x => x.YearModel).IsRequired();
        }
    }
}