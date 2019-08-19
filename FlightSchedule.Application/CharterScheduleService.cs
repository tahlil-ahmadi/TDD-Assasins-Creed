using System;
using System.Collections.Generic;
using System.Linq;
using FlightSchedule.Application.Contracts;
using FlightSchedule.Domain.Model;
using FlightSchedule.Persistence.EF;
using Microsoft.EntityFrameworkCore;

namespace FlightSchedule.Application
{
    public class CharterScheduleService : ICharterScheduleService
    {
        private readonly FlightScheduleDbContext _dbContext;
        public CharterScheduleService(FlightScheduleDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Guid Create(CreateCharterScheduleDto dto)
        {
            var charterSchedule = new CharterSchedule(dto.Airline, dto.Airplane, dto.FlightNo, dto.Seats);
            foreach (var table in dto.TimeTables)
            {
                var depart = TimeSpan.Parse(table.DepartureTime);
                var arrive = TimeSpan.Parse(table.ArriveDate);
                charterSchedule.AddTimeTable(new CharterTimeTable(table.Day, table.Origin, table.Destination, depart, arrive));
            }
            _dbContext.CharterSchedules.Add(charterSchedule);
            _dbContext.SaveChanges();
            return charterSchedule.Id;
        }
        public CharterScheduleDto GetById(Guid id)
        {
            var schedule = _dbContext.CharterSchedules
                .Include(a => a.TimeTables)
                .First(a => a.Id == id);

            var output = new CharterScheduleDto()
            {
                Id = schedule.Id,
                Airline = schedule.Airline,
                Airplane = schedule.Airplane,
                FlightNo = schedule.FlightNo,
                Seats = schedule.Seats,
                TimeTables = ConvertTimeTables(schedule.TimeTables)
            };
            return output;
        }

        private List<TimeTableDto> ConvertTimeTables(List<CharterTimeTable> timetables)
        {
            return timetables.Select(a => new TimeTableDto()
            {
                Id = a.Id,
                Depart = a.Depart.ToShortTime(),
                Arrive = a.Arrive.ToShortTime(),
                Destination = a.Destination,
                Origin = a.Origin
            }).ToList();
        }
    }
}
