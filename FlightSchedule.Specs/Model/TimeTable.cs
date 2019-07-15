using System;

namespace FlightSchedule.Specs.Model
{
    public class TimeTable
    {
        public DayOfWeek DayOfWeek { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
    }
}