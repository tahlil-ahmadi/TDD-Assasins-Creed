using System;
using System.Linq;
using System.Net.Http;
using FlightSchedule.Specs.Model;
using FlightSchedule.Specs.Tasks;
using Newtonsoft.Json;
using NFluent;
using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Questions;
using Suzianna.Rest;
using Suzianna.Rest.Screenplay.Interactions;
using Suzianna.Rest.Screenplay.Questions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace FlightSchedule.Specs
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private readonly Stage _stage;
        private CharterSchedule model;
        public SpecFlowFeature1Steps(Stage stage)
        {
            _stage = stage;
        }

       
        [Given(@"he has entered the following charter schedule")]
        public void WhenHeDefinesTheFollowingCharterSchedule(Table table)
        {
            model = table.CreateInstance<CharterSchedule>();
        }
        
        [Given(@"He has assigned the following timetable to it")]
        public void WhenHeHasAssignedTheFollowingTimetableToIt(Table table)
        {
            model.TimeTable = table.CreateSet<TimeTable>().ToList();
        }

        [When("he submits the charter schedule")]
        public void WhenHeSubmitsTheCharterSchedule()
        {
            _stage.ActorInTheSpotlight.AttemptsTo(Define.CharterSchedule(model));
        }

        [Then(@"it should be appear in the list of charter schedules")]
        public void ThenItShouldBeAppearInTheListOfCharterSchedules()
        {
            var location = _stage.ActorInTheSpotlight.AsksFor(LastResponse.Header(HttpHeaders.Location));
            //TODO: remove it from here
            _stage.ActorInTheSpotlight.AttemptsTo(Get.ResourceAt(location));

            _stage.ActorInTheSpotlight.Should(See.That(LastResponse.Content<CharterSchedule>())).IsEqualTo(this.model);
        }
    }
}
