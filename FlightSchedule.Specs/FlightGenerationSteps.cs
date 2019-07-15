using System;
using FlightSchedule.Specs.Screenplay;
using TechTalk.SpecFlow;

namespace FlightSchedule.Specs
{
    [Binding]
    public class FlightGenerationSteps
    {
        private readonly Stage _stage;
        public FlightGenerationSteps(Stage stage)
        {
            _stage = stage;
        }

        [Given(@"'(.*)' is a flight agency manager")]
        public void GivenIsAnFlightAgencyManager(string name)
        {
            var actor = new Actor(name);
            this._stage.ShineSpotlightOn(actor);
        }
        
        [Given(@"He has defined a charter schedule as following")]
        public void GivenHeHasDefinedACharterScheduleAsFollowing(Table table)
        {
        }

        [When(@"he try to generate flights in range")]
        public void WhenHeTryToGenerateFlightsInRange(Table table)
        {
        }
        
        [Then(@"the following flights should be generated")]
        public void ThenTheFollowingFlightsShouldBeGenerated(Table table)
        {
        }
    }
}
