using System;
using System.Linq;
using System.Net.Http;
using FlightSchedule.Application.Contracts;
using FlightSchedule.Specs.Tasks;
using FluentAssertions;
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
        private CreateCharterScheduleDto model;
        public SpecFlowFeature1Steps(Stage stage)
        {
            _stage = stage;
        }

       
        [Given(@"he has entered the following charter schedule")]
        public void WhenHeDefinesTheFollowingCharterSchedule(Table table)
        {
            model = table.CreateInstance<CreateCharterScheduleDto>();
        }
        
        [Given(@"He has assigned the following timetable to it")]
        public void WhenHeHasAssignedTheFollowingTimetableToIt(Table table)
        {
            model.TimeTables = table.CreateSet<CreateCharterTimeTableDto>().ToList();
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
            _stage.ActorInTheSpotlight.AttemptsTo(Get.ResourceAt(location));
            var result = _stage.ActorInTheSpotlight.AsksFor(LastResponse.Content<CharterTemplateDto>());
            result.Should().BeEquivalentTo(this.model, a=>a.ExcludingMissingMembers());
        }
    }
}
