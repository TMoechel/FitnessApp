namespace FitnessApp.Activity
{
    public class RunActivity : FitnessApp.Activity.SportActivity
    {
        public RunActivity(DateTime dateOfActivity, double distance, TimeSpan timeTaken, Feeling feeling) : base(dateOfActivity, distance, timeTaken, feeling)
        {
        }
    }
}