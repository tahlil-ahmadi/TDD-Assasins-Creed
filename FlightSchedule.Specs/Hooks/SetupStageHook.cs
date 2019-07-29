using System;
using System.Collections.Generic;
using System.Text;
using BoDi;
using Suzianna.Core.Screenplay;
using TechTalk.SpecFlow;
using CallAnApi = Suzianna.Rest.Screenplay.Abilities.CallAnApi;

namespace FlightSchedule.Specs.Hooks
{
    [Binding]
    public class SetupStageHook
    {
        private readonly IObjectContainer _container;
        public SetupStageHook(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void Setup()
        {
            //TODO: don't hardcode the base url :|
            var abilities = new List<IAbility> { CallAnApi.At("http://localhost:5000/api/") };
            var cast = Cast.WhereEveryoneCan(abilities);
            var stage = new Stage(cast);
            _container.RegisterInstanceAs(stage);
        }
    }
}
