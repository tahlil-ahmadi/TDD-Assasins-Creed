using FlightSchedule.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightSchedule.Persistence.EF.Mappings
{
    public class CharterTimeTableMapping : IEntityTypeConfiguration<CharterTimeTable>
    {
        public void Configure(EntityTypeBuilder<CharterTimeTable> builder)
        {
            builder.Property(a => a.Origin);
            builder.Property(a => a.Destination);
            builder.Property(a => a.Depart);
            builder.Property(a => a.Arrive);
        }
    }
}