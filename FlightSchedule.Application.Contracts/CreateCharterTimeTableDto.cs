using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Application.Contracts
{
    public class CreateCharterTimeTableDto
    {
        public DayOfWeek Day { get;  set; }
        public string Origin { get;  set; }
        public string Destination { get;  set; }
        public string Depart { get;  set; }
        public string Arrive { get;  set; }
    }
}
