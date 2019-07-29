using System;
using System.Collections.Generic;
using System.Text;
using Suzianna.Hosting.NetCoreHosting;
using TechTalk.SpecFlow;

namespace FlightSchedule.Specs.Hooks
{
    [Binding]
    public static class HostingHook
    {
        private static DotNetCoreHost _host;

        [BeforeTestRun]
        public static void StartSutHost()
        {
            var options = new DotNetCoreHostOptions()
            {
                //TODO: Fix This O_o
                CsProjectPath = @"D:\Sources\TDD - Assasins Creed\Session 07\FlightSchedule\FlightSchedule.RestApi",
                Port = 5000,
            };
            _host = new DotNetCoreHost(options);
            _host.Start();
        }

        [AfterTestRun]
        public static void StopSutHost()
        {
            _host.Stop();
        }
    }
}
