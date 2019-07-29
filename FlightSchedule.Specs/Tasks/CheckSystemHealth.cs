using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;

namespace FlightSchedule.Specs.Tasks
{
    public class CheckSystemHealth : IPerformable
    {
        public void PerformAs<T>(T actor) where T : Actor
        {
            using (var client = new HttpClient())
            {
                var message = client.GetAsync("http://localhost:5000/api/HealthCheck").Result;
                var result = message.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
