using FlightSchedule.Domain.Model;
using FlightSchedule.Domain.Tests.TestUtils;
using FluentAssertions;
using Xunit;

namespace FlightSchedule.Domain.Tests.Tests
{
    public class CharterScheduleTests
    {
        [Fact]
        public void should_be_constructed_properly()
        {
            var airline = "Mahan";
            var airplane = "Airbus-320";
            var flightNo = "WK-550";
            var seats = 120;

            var charter = new CharterSchedule(airline, airplane, flightNo, seats);

            charter.Id.Should().NotBeEmpty();
            charter.Airline.Should().Be(airline);
            charter.Airplane.Should().Be(airplane);
            charter.FlightNo.Should().Be(flightNo);
            charter.Seats.Should().Be(seats);
        }

        [Fact]
        public void should_be_able_to_assign_timetable()
        {
            var charter = CharterScheduleFactory.GetSomeCharterSchedule();
            var timeTable = CharterTimeTableFactory.CreateSomeTimetable();

            charter.AddTimeTable(timeTable);

            charter.TimeTables.Should().HaveCount(1).And.Contain(timeTable);
        }
    }
}
