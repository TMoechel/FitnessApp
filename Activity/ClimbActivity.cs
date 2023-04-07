namespace FitnessApp.Activity
{
    public class ClimbActivity : FitnessApp.Activity.SportActivity
    {
        public ClimbActivity(DateTime dateOfActivity, double distance, TimeSpan timeTaken, Feeling feeling) : base(dateOfActivity, distance, timeTaken, feeling)
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