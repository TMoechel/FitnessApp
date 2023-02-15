using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Activity
{
    // this is the Activity class
    public class Activity
    {
        public static void ChooseActivity(List<SportsType> sportstype)
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

            Activity activity = null;

            switch (activityType)
            {
                case "1":
                    activity = new BikeActivity();
                    break;
                case "2":
                    activity = new ClimbActivity();
                    break;
                case "3":
                    activity = new RunActivity();
                    break;
                case "4":
                    activity = new SwinActivity();
                    break;
                default:
                    Console.WriteLine("Invalid activity selection. Please try again.");
                    break;
            }
        }
    }
}