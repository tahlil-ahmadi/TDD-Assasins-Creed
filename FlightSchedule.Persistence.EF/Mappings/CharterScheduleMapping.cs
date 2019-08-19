using System;
using System.Collections.Generic;
using System.Text;
using FlightSchedule.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightSchedule.Persistence.EF.Mappings
{
    public class CharterScheduleMapping : IEntityTypeConfiguration<CharterSchedule>
    {
        public void Configure(EntityTypeBuilder<CharterSchedule> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Airline);
            builder.Property(a => a.Airplane);
            builder.Property(a => a.FlightNo);
            builder.Property(a => a.Seats);

            builder.HasMany(a => a.TimeTables).WithOne().IsRequired();
        }
    }
}
