using System;
using System.Collections.Generic;
using System.Text;
using FlightSchedule.Domain.Model;
using FlightSchedule.Domain.Services;
using FlightSchedule.Domain.Tests.Constants;
using FlightSchedule.Domain.Tests.TestUtils;
using FluentAssertions;
using Xunit;
using static FlightSchedule.Domain.Tests.Constants.Airports;

namespace FlightSchedule.Domain.Tests.Tests
{
    public class FlightGenerationServiceTests
    {
        [Fact]
        public void should_generate_flights_based_on_charter_schedule_when_arrive_is_in_same_day_as_depart()
        {
            var schedule = new CharterScheduleBuilder()
                .WithFlightNo("4070")
                .WithTimeTable(DayOfWeek.Monday, IKA, HKT, "05:00", "10:00")
                .WithTimeTable(DayOfWeek.Wednesday, HKT, IKA, "15:00", "20:00")
                .Build();

            var start = DateTime.Parse("2019-08-19");   //Monday
            var end = DateTime.Parse("2019-08-26");

            var expected = new List<Flight>()
            {
                new Flight(){ Origin = IKA, Destination = HKT, FlightNo = "4070",
                    Depart = DateTime.Parse("2019-08-19 05:00:00"),
                    Arrive = DateTime.Parse("2019-08-19 10:00:00"),
                },
                new Flight(){ Origin = HKT, Destination = IKA, FlightNo = "4070",
                    Depart = DateTime.Parse("2019-08-21 15:00:00"),
                    Arrive = DateTime.Parse("2019-08-21 20:00:00"),
                },
                new Flight(){ Origin = IKA, Destination = HKT, FlightNo = "4070",
                    Depart = DateTime.Parse("2019-08-26 05:00:00"),
                    Arrive = DateTime.Parse("2019-08-26 10:00:00"),
                },
            };

            var actual = FlightGenerationService.Generate(start, end, schedule);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(Skip = "OH")]
        public void should_generate_flights_based_on_charter_schedule_when_arrive_is_different_from_depart()
        {
            var schedule = new CharterSchedule("Qatar Airways", "Airbus", "4070", 250);
            var depart1 = TimeSpan.Parse("21:00");
            var arrive1 = TimeSpan.Parse("03:00");
            schedule.AddTimeTable(new CharterTimeTable(DayOfWeek.Monday, "IKA", "HKT", depart1, arrive1));

            var start = DateTime.Parse("2019-08-19");   //Monday
            var end = DateTime.Parse("2019-08-22");


            var expected = new List<Flight>()
            {
                new Flight(){
                    Origin = "IKA",
                    Destination = "HKT",
                    FlightNo = "4070",
                    Depart = DateTime.Parse("2019-08-19 21:00:00"),
                    Arrive = DateTime.Parse("2019-08-20 03:00:00"),
                },
            };

            var actual = FlightGenerationService.Generate(start, end, schedule);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
