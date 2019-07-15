using System;
using System.Collections.Generic;
using System.Text;
using FlightSchedule.Domain.Model;

namespace FlightSchedule.Domain.Tests.TestUtils
{
    internal static class CharterScheduleFactory
    {
        public static CharterSchedule GetSomeCharterSchedule()
        {
            return new CharterSchedule("","","",0);
        }
    }
}
