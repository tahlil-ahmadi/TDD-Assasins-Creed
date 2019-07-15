using System;
using System.Linq;
using System.Net.Http;
using FlightSchedule.Specs.Model;
using FlightSchedule.Specs.Screenplay;
using FlightSchedule.Specs.Tasks;
using Newtonsoft.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace FlightSchedule.Specs
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private readonly Stage _stage;
        public SpecFlowFeature1Steps(Stage stage)
        {
            _stage = stage;
        }

        private CharterScheduleRequest request;
       
        [Given(@"he has entered the following charter schedule")]
        public void WhenHeDefinesTheFollowingCharterSchedule(Table table)
        {
            request = table.CreateInstance<CharterScheduleRequest>();
        }
        
        [Given(@"He has assigned the following timetable to it")]
        public void WhenHeHasAssignedTheFollowingTimetableToIt(Table table)
        {
            request.TimeTable = table.CreateSet<TimeTable>().ToList();
        }

        [When("he submits the charter schedule")]
        public void WhenHeSubmitsTheCharterSchedule()
        {
            _stage.ActorOnSpotlight.AttemptsTo(Define.CharterSchedule(request));
        }

        [Then(@"it should be appear in the list of charter schedules")]
        public void ThenItShouldBeAppearInTheListOfCharterSchedules()
        {
        }
    }
}
