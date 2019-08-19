using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Domain.Model
{
    public class Flight
    {
        public string FlightNo { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime Depart { get; set; }
        public DateTime Arrive { get; set; }
    }
}
