using System;
using System.Collections.Generic;
using System.Text;
using FlightSchedule.Domain.Model;

namespace FlightSchedule.Domain.Tests.TestUtils
{
    internal static class CharterTimeTableFactory
    {
        public static CharterTimeTable CreateSomeTimetable()
        {
            var depart = DateTime.Now.AddDays(1);
            var arrive = DateTime.Now.AddDays(5);
            var timeTable = new CharterTimeTable("IKA", "DXB", depart, arrive);
            return timeTable;
        }
    }
}
