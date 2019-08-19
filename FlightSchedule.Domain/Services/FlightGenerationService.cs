using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlightSchedule.Domain.Model;

namespace FlightSchedule.Domain.Services
{
    public static class FlightGenerationService
    {
        public static List<Flight> Generate(DateTime start, DateTime end, CharterSchedule baseSchedule)
        {
            var flights =new List<Flight>();
            foreach (var date in EachDay(start, end))
            {
                var candidate = baseSchedule.TimeTables.FirstOrDefault(a => a.Day == date.DayOfWeek);
                if (candidate == null) continue;

                var flight = new Flight()
                {
                    FlightNo = baseSchedule.FlightNo,
                    Origin = candidate.Origin,
                    Destination = candidate.Destination,
                    Depart = date.Add(candidate.Depart),
                    Arrive = date.Add(candidate.Arrive),
                };
                flights.Add(flight);
            }
            return flights;
        }

        public static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
    }
}
