using FlightSchedule.Specs.Model;
using Suzianna.Core.Screenplay;

namespace FlightSchedule.Specs.Tasks
{
    public static class Define
    {
        public static IPerformable CharterSchedule(CharterSchedule request)
        {
            return new DefineCharterSchedule(request);
        }
    }
}