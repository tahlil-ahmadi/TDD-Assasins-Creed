using System;
using System.Collections.Generic;
using System.Text;
using FlightSchedule.Domain.Model;
using FlightSchedule.Persistence.EF.Mappings;
using Microsoft.EntityFrameworkCore;

namespace FlightSchedule.Persistence.EF
{
    public class FlightScheduleDbContext : DbContext
    {
        public DbSet<CharterSchedule> CharterSchedules { get; set; }
        public DbSet<CharterTimeTable> CharterTimeTables { get; set; }
        public FlightScheduleDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CharterScheduleMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
