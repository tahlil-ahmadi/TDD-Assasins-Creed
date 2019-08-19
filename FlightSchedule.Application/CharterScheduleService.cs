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
            var charterSchedule = new CharterSchedule(dto.Airline, dto.Airline, dto.FlightNo, dto.Seats);
            charterSchedule.AddTimeTable(new CharterTimeTable("IKA","DXB", DateTime.Now, DateTime.Now.AddDays(1)));
            _dbContext.CharterSchedules.Add(charterSchedule);
            _dbContext.SaveChanges();
            return charterSchedule.Id;
        }
        public CharterTemplateDto GetById(Guid id)
        {
            var schedule = _dbContext.CharterSchedules
                .Include(a => a.TimeTables)
                .First(a => a.Id == id);

            var output = new CharterTemplateDto()
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
                Depart = a.Depart,
                Arrive = a.Arrive,
                Destination = a.Destination,
                Origin = a.Origin

            }).ToList();
        }
    }
}
