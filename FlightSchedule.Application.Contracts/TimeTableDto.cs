using System;

namespace FlightSchedule.Application.Contracts
{
    public class TimeTableDto
    {
        public long Id { get; set; }
        public string Origin { get;  set; }
        public string Destination { get;  set; }
        public string Depart { get;  set; }
        public string Arrive { get;  set; }
    }
}