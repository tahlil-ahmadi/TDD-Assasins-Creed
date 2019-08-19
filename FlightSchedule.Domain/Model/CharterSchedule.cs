using System;
using System.Collections.Generic;

namespace FlightSchedule.Domain.Model
{
    public class CharterSchedule
    {
        public Guid Id { get; set; }
        public string Airline { get; private set; }
        public string Airplane { get; private set; }
        public string FlightNo { get; private set; }
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