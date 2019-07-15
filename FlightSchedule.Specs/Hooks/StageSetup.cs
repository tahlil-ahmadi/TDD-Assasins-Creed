using System;
using System.Collections.Generic;
using System.Text;
using BoDi;
using FlightSchedule.Specs.Screenplay;
using TechTalk.SpecFlow;

namespace FlightSchedule.Specs.Hooks
{
    [Binding]
    public class StageSetup
    {
        private readonly IObjectContainer _container;
        public StageSetup(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void Setup()
        {
        }
    }
}
