using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using FlightSchedule.Specs.Model;
using FlightSchedule.Specs.Screenplay;
using Newtonsoft.Json;

namespace FlightSchedule.Specs.Tasks
{
    public static class Define
    {
        public static IPerformable CharterSchedule(CharterScheduleRequest request)
        {
            return new DefineCharterSchedule(request);
        }
    }

    public class DefineCharterSchedule : IPerformable
    {
        private readonly CharterScheduleRequest _model;
        public DefineCharterSchedule(CharterScheduleRequest model)
        {
            _model = model;
        }
        public void Perform()
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(this._model);
                var content = new StringContent(json);
                client.PostAsync("http://localhost:5050/api/charterSchedules", content).Wait();
            }
        }
    }
}
