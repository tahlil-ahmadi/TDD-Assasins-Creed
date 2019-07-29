using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Specs.Model
{
    public class CharterSchedule
    {
        public string FlightNo { get; set; }
        public string Seats { get; set; }
        public string Airplane { get; set; }
        public string Airline { get; set; }
        public List<TimeTable> TimeTable { get; set; }
    }
}
