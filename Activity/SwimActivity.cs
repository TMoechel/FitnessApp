namespace FitnessApp.Activity
{
    public class SwimActivity : FitnessApp.Activity.SportActivity
    {
        public SwimActivity(double distance, TimeSpan timeTaken, Feeling feeling) : base(distance, timeTaken, feeling)
        {
        }

        public override double CalculateAverageSpeed()
        {
            return CalculateAverageInMPerSecond();
        }
    }
}