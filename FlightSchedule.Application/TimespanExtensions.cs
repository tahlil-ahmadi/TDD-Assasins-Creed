using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Application
{
    public static class TimespanExtensions
    {
        public static string ToShortTime(this TimeSpan time)
        {
            return time.ToString(@"hh\:mm");
        }
    }
}
