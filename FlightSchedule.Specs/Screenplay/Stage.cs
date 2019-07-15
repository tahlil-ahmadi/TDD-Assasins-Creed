using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Specs.Screenplay
{
    public class Stage
    {
        private Cast _cast;
        public Actor ActorOnSpotlight { get; private set; }
        public Stage()
        {
            this._cast = new Cast();   
        }
        public void ShineSpotlightOn(Actor actor)
        {
            _cast.AddActor(actor);
            this.ActorOnSpotlight = actor;
        }
    }
}
