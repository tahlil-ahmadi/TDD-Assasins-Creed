using System;

namespace FlightSchedule.Domain.Model
{
    public class CharterTimeTable
    {
        public DayOfWeek Day { get; private set; }
        public string Origin { get; private set; }
        public string Destination { get; private set; }
        public TimeSpan Depart { get; private set; }
        public TimeSpan Arrive { get; private set; }

        public CharterTimeTable(DayOfWeek day, string origin, string destination, TimeSpan depart, TimeSpan arrive)
        {
            Day = day;
            Origin = origin;
            Destination = destination;
            Depart = depart;
            Arrive = arrive;
        }
    }
}