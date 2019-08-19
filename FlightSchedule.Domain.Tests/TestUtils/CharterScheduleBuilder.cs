using System;
using System.Collections.Generic;
using System.Text;
using FlightSchedule.Domain.Model;

namespace FlightSchedule.Domain.Tests.TestUtils
{
    public class CharterScheduleBuilder
    {
        private string _flightNo;
        private readonly List<CharterTimeTable> _timeTables;
        public CharterScheduleBuilder()
        {
            _timeTables = new List<CharterTimeTable>();    
        }
        public CharterScheduleBuilder WithFlightNo(string flightNo)
        {
            this._flightNo = flightNo;
            return this;
        }
        public CharterScheduleBuilder WithTimeTable(DayOfWeek day, string origin, string destination,
            string depart, string arrive)
        {
            var departTime = TimeSpan.Parse(depart);
            var arriveTime = TimeSpan.Parse(arrive);
            _timeTables.Add(new CharterTimeTable(day, origin, destination, departTime, arriveTime));
            return this;
        }

        public CharterSchedule Build()
        {
            var schedule =  new CharterSchedule("Emirates", "Pride 305", this._flightNo, 5);
            this._timeTables.ForEach(a=> schedule.AddTimeTable(a));
            return schedule;
        }
    }
}
