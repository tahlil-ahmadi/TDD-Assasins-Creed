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
        public string DepartureTime { get;  set; }
        public string ArriveDate { get;  set; }
    }
}
