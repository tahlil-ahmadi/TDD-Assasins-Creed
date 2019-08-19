using System;
using System.Collections.Generic;

namespace FlightSchedule.Application.Contracts
{
    public class CreateCharterScheduleDto
    {
        public string Airline { get;  set; }
        public string Airplane { get; set; }
        public string FlightNo { get; set; }
        public int Seats { get; set; }
        public List<CreateCharterTimeTableDto> TimeTables { get;  set; }
    }
}
