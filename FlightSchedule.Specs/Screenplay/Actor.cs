namespace FlightSchedule.Specs.Screenplay
{
    public class Actor
    {
        public string Name { get; private set; }
        public Actor(string name)
        {
            Name = name;
        }

        public void AttemptsTo(IPerformable performable)
        {
            performable.Perform();
        }
    }
}
