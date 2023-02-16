using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp;

namespace FitnessApp.Activity
{
    // this is the Activity class
    public class Activity
    {

        private double averageSpeed;
        private double distance;
        private double timeTaken;

        public double Distance 
        {
            get { return distance; }
            set { distance = value; }
        }

        public double TimeTaken
        {
            get { return timeTaken; }
            set { timeTaken = value; }
        }

        public Activity(double distance, double timeTaken)
        {
            Distance = distance;
            TimeTaken = timeTaken;
        }

        public static void EnterActivity(List<Activity> activities)
        {
            Console.WriteLine("What type of activity do you want to enter?");
            Console.WriteLine("1. Bike Activity\n2. Climb Activity\n3. Run Activity\n4. Swim Activity");
            Console.Write("Your selection: ");
            string activityType = Console.ReadLine();

            if (activityType != "1" && activityType != "2" && activityType != "3"
                && activityType != "4" && activityType != "5")
            {
                Console.WriteLine("Invalid activity!");
                return;
            }

            Console.Write("Enter Distance: ");
            string distance = Console.ReadLine();
            double distance1 = double.Parse(distance);

            Console.Write("Enter time taken: ");
            string time = Console.ReadLine();
            double time1 = double.Parse(time);

            Activity activity = null;

            switch (activityType)
            {
                case "1":
                    activity = new BikeActivity(distance1, time1);
                    break;
                /*case "2":
                    activity = new ClimbActivity(distance, time);
                    break;
                case "3":
                    activity = new RunActivity(distance, time);
                    break;
                case "4":
                    activity = new SwinActivity(distance, time);
                    break;*/
                default:
                    Console.WriteLine("Invalid activity selection. Please try again.");
                    break;
            }
            activities.Add(activity);
            Console.WriteLine("New Activity created!\n\n");
        }

        internal static void ViewAllActivities(List<Activity> activities)
        {
            for (int i = 0; i < activities.Count; i++)
            {
                activities[i].DisplayAllActivities();
            }
        }

        public void DisplayAllActivities()
        {
            Console.WriteLine($"(\nDistance: \t{Distance} \nTime: \t{TimeTaken})");
        }
    }
}