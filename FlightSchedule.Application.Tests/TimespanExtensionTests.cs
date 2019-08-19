using System;
using FluentAssertions;
using Xunit;

namespace FlightSchedule.Application.Tests
{
    public class TimespanExtensionTests
    {
        [Theory]
        [InlineData(5, 10, "05:10")]
        [InlineData(21, 30, "21:30")]
        public void should_return_hour_and_minutes(int hour, int minute, string expected)
        {
            var timespan = new TimeSpan(0, hour,minute,0);

            var actual = timespan.ToShortTime();

            actual.Should().Be(expected);
        }
    }
}
