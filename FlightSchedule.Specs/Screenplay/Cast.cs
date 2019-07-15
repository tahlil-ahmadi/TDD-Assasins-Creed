using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Specs.Screenplay
{
    public class Cast
    {
        private List<Actor> _actors;
        public Cast()
        {
            this._actors = new List<Actor>();
        }
        public void AddActor(Actor actor)
        {
            this._actors.Add(actor);
        }
    }
}
