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

        public List<SportActivity> GetActivitiesByDate(DateTime dateOfActivity)
        {
            List<SportActivity> activitiesByDate = new List<SportActivity>();
            foreach (SportActivity activity in _activityList)
            {
                if (activity.ActivityDate.Date == dateOfActivity.Date)
                {
                    activitiesByDate.Add(activity);
                }
            }
            return activitiesByDate;
        }
    }
}
