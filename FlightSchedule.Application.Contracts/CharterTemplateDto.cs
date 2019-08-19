using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Application.Contracts
{
    public class CharterScheduleDto
    {
        public Guid Id { get; set; }
        public string Airline { get; set; }
        public string Airplane { get; set; }
        public string FlightNo { get; set; }
        public int Seats { get; set; }
        public List<TimeTableDto> TimeTables { get;  set; }
    }
}
