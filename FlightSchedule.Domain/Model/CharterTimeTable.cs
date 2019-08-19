using System;

namespace FlightSchedule.Domain.Model
{
    public class CharterTimeTable
    {
        public long Id { get; set; }
        public string Origin { get; private set; }
        public string Destination { get; private set; }
        public DateTime Depart { get; private set; }
        public DateTime Arrive { get; private set; }

        public CharterTimeTable(string origin, string destination, DateTime depart, DateTime arrive)
        {
            Origin = origin;
            Destination = destination;
            Depart = depart;
            Arrive = arrive;
        }
    }
}