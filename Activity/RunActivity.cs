namespace FitnessApp.Activity
{
    public class RunActivity : SportActivity
    {
        public override string DistanceUnit => "Km";
        public override double Distance { get => Distance / 1000; set => base.Distance = value; }

        public RunActivity(DateTime dateOfActivity, double distance, TimeSpan timeTaken, Feeling feeling) : base(dateOfActivity, distance, timeTaken, feeling)
        {
        }
    }
}