namespace FitnessApp.Activity
{
    public class ClimbActivity : SportActivity
    {
        public override string ActivityName => "Climbing";
        public override string DistanceUnit => "m";

        public ClimbActivity(DateTime dateOfActivity, double distance, TimeSpan timeTaken, Feeling feeling) : base(dateOfActivity, distance, timeTaken, feeling)
        {

        }
        public override double CalculateAverageSpeed()
        {
            return CalculateAverageInMPerSecond();
        }

        public override string GetVelocityUnit()
        {
            return ShowMetersPerSecond();
        }
    }
}