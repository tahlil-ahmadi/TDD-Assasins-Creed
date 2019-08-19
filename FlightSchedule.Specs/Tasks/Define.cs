using FlightSchedule.Application.Contracts;
using Suzianna.Core.Screenplay;

namespace FlightSchedule.Specs.Tasks
{
    public static class Define
    {
        public static IPerformable CharterSchedule(CreateCharterScheduleDto request)
        {
            return new DefineCharterSchedule(request);
        }
    }
}