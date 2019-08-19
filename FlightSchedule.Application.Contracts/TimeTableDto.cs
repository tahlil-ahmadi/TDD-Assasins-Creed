using System;

namespace FlightSchedule.Application.Contracts
{
    public class TimeTableDto
    {
        public long Id { get; set; }
        public string Origin { get;  set; }
        public string Destination { get;  set; }
        public DateTime Depart { get;  set; }
        public DateTime Arrive { get;  set; }
    }
}