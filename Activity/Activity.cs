using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.Activity;

namespace FitnessApp.Activity
{
    // this is the Activity class
    public class Activity
    {
        private double averageSpeed;
        private double distance;
        private double timeTaken;
        private string feeling;

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

        public string Feeling
        {
            get { return feeling; }
            set { feeling = value; }
        }

        public Activity(double distance, double timeTaken, string? feeling)
        {
            Distance = distance;
            TimeTaken = timeTaken;
            Feeling = feeling;
        }

        public double CalculateAverage => averageSpeed = Distance / TimeTaken;

        internal static void EnterActivity(List<Activity> activities)
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

            Console.Write("How did you feel after the activity?:\n1 = Bad \n2 = Ok \n3 = Good \n4 = Strong \n5 = Very Strong \nChoose a number: ");
            string feeling = Console.ReadLine();
            int feeling1 = int.Parse(feeling);

            Activity activity = null;

            switch (activityType)
            {
                case "1":
                    activity = new BikeActivity(distance1, time1, feeling);
                    break;
                case "2":
                    activity = new ClimbActivity(distance1, time1, feeling);
                    break;
                case "3":
                    activity = new RunActivity(distance1, time1, feeling);
                    break;
                case "4":
                    activity = new SwinActivity(distance1, time1, feeling);
                    break;
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
            Console.WriteLine($"Activity: \t \nDistance: \t{Distance} \nTime: \t{TimeTaken} \nFeeling: \t{Feeling} \nAverage Speed: \t{CalculateAverage}");
        }

        internal static void LoadActivity(List<Activity> activities)
        {
            throw new NotImplementedException();
        }
    }
}