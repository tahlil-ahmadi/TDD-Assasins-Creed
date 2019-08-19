using System;
using System.Collections.Generic;
using System.Text;
using FlightSchedule.Application.Contracts;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Core.Screenplay.Questions;
using Suzianna.Rest;
using Suzianna.Rest.Screenplay.Interactions;
using Suzianna.Rest.Screenplay.Questions;

namespace FlightSchedule.Specs.Questions
{
    public class CreatedCharterSchedule : IQuestion<CharterScheduleDto>
    {
        public CharterScheduleDto AnsweredBy(Actor actor)
        {
            var location = actor.AsksFor(LastResponse.Header(HttpHeaders.Location));
            actor.AttemptsTo(Get.ResourceAt(location));
            return actor.AsksFor(LastResponse.Content<CharterScheduleDto>());
        }
    }
}
