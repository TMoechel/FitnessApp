using System.ComponentModel;
using FitnessApp.Activity;

namespace FitnessApp.Data
{
    internal class ActivityRepository
    {
        private static List<IActivity> _activityList = new List<IActivity>();

        public static void Add(IActivity activity)
        {
            _activityList.Add(activity);
        }

        public static List<IActivity> GetAll()
        {
            return _activityList;
        }

    }
}
