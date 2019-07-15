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
            var depart = TimeSpan.Parse("08:00");
            var arrive = TimeSpan.Parse("09:30");
            var timeTable = new CharterTimeTable(DayOfWeek.Monday, "IKA", "DXB", depart, arrive);
            return timeTable;
        }
    }
}
