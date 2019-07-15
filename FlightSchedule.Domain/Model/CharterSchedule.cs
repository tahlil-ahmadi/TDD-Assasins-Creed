using System;
using System.Collections.Generic;

namespace FlightSchedule.Domain.Model
{
    public class CharterSchedule
    {
        public Guid Id { get; set; }
        public string Airline { get; }
        public string Airplane { get; }
        public string FlightNo { get; }
        public int Seats { get; }
        public List<CharterTimeTable> TimeTables { get; private set; }

        public CharterSchedule(string airline, string airplane, string flightNo, int seats)
        {
            this.Id = Guid.NewGuid();
            Airline = airline;
            Airplane = airplane;
            FlightNo = flightNo;
            Seats = seats;
        }

        public void AddTimeTable(CharterTimeTable timeTables)
        {
            if (this.TimeTables == null) this.TimeTables = new List<CharterTimeTable>();
            this.TimeTables.Add(timeTables);
        }
    }
}