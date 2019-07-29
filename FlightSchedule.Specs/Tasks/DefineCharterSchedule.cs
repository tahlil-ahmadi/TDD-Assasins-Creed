using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using FlightSchedule.Specs.Model;
using Newtonsoft.Json;
using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Interactions;

namespace FlightSchedule.Specs.Tasks
{
    public class DefineCharterSchedule : IPerformable
    {
        private readonly CharterSchedule _model;
        public DefineCharterSchedule(CharterSchedule model)
        {
            _model = model;
        }
        public void PerformAs<T>(T actor) where T : Actor
        {
            actor.AttemptsTo(Post.DataAsJson(_model).To("CharterSchedules"));
        }
    }
}
