using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.Activity;

namespace FitnessApp.UI
{
    public class ActivityDialog
    {
        private static string[] validActivities = { "1", "2", "3", "4" };
        
        public static void EnterActivity()
        {
            Console.WriteLine("What type of activity do you want to enter?");
            Console.WriteLine("1. Bike Activity\n2. Climb Activity\n3. Run Activity\n4. Swim Activity");
            Console.Write("Your selection: ");
            
            string? activityTypeInput = Console.ReadLine();
            if (activityTypeInput != null)
            {
                ActivityType activityType = (ActivityType)int.Parse(activityTypeInput!);

                if (!validActivities.Contains(activityTypeInput))
                {
                    Console.WriteLine("Invalid activity!");
                    return;
                }

                OpenActivityDialog(activityType);
                Console.WriteLine("New Activity created!\n\n");
            }
        }

        private static void OpenActivityDialog(ActivityType activityType)
        {
            switch (activityType)
            {
                case ActivityType.Biking:
                    AddSportActivity();
                    break;
                case ActivityType.Climbing:
                    AddClimbingActivity();  // this is a special activity with other data
                    break;
                case ActivityType.Running:
                    AddSportActivity();
                    break;
                case ActivityType.Swimming:
                    AddSportActivity();
                    break;
                default: throw new ArgumentException("Invalid Activity");
            }
        }

        private static void AddClimbingActivity()
        {
            AddSportActivity();
        }

        private static void AddSportActivity()
        {
            Console.Write("Enter Distance: ");
            string? distance = Console.ReadLine();
            double distanceInputToDouble = double.Parse(distance);

            Console.Write("Enter time taken in hh:mm:ss: ");
            string? timeTaken = Console.ReadLine();
            DateTime timeInputToDateTime = DateTime.Parse(timeTaken);


            Console.Write("How did you feel after the activity?:\n1 = Bad \n2 = Ok \n3 = Good \n4 = Strong \n5 = Very Strong \nChoose a number: ");
            string? feelingInput = Console.ReadLine();
            int feelingInputToInt = int.Parse(feelingInput);
            
            Feeling feeling = (Feeling)(feelingInputToInt);

            

        }
    }
}
