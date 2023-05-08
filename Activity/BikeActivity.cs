namespace FitnessApp.Activity
{
    public class BikeActivity : SportActivity
    {
        public override string DistanceUnit => "Km";

        public override double GetActivityDistance()
        {
            return Distance / 1000;
        }

        public BikeActivity(DateTime dateOfActivity, double distance, TimeSpan timeTaken, Feeling feeling) : base(dateOfActivity, distance, timeTaken, feeling)
        {

        }
    }
}