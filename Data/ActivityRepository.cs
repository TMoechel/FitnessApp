using FitnessApp.Activity;

namespace FitnessApp.Data
{
    internal class ActivityRepository
    {
        private static readonly List<ISportActivity> _activityList = new ();

        public static void Add(ISportActivity sportActivity)
        {
            _activityList.Add(sportActivity);
        }

        public static List<ISportActivity> GetAll()
        {
            return _activityList;
        }

    }
}
