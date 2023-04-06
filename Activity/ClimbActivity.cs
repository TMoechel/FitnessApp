namespace FitnessApp.Activity
{
    public class ClimbActivity : FitnessApp.Activity.SportActivity
    {
        public ClimbActivity(double distanceKm, TimeSpan timeTaken, Feeling feeling) : base(distanceKm, timeTaken, feeling)
        {

        }
        public override double CalculateAverageSpeed()
        {
            return CalculateAverageInMPerSecond();
        }

        public override string ShowKmM()
        {
            return ShowMPerSecond();
        }
    }
}