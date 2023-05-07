namespace FitnessApp.Activity
{
    public class SwimActivity : SportActivity
    {
        public override string ActivityName => "Swimming";
        public override string DistanceUnit => "m";

        public SwimActivity(DateTime dateOfActivity, double distance, TimeSpan timeTaken, Feeling feeling) : base(dateOfActivity, distance, timeTaken, feeling)
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