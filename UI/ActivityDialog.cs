using FitnessApp.Activity;
using FitnessApp.Data;

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
                    AddBikeActivity(activityType);
                    break;
                case ActivityType.Climbing:
                    AddClimbingActivity(activityType);  // this is a special activity with other data
                    break;
                case ActivityType.Running:
                    AddRunActivity(activityType);
                    break;
                case ActivityType.Swimming:
                    AddSwimActivity(activityType);
                    break;
                default: throw new ArgumentException("Invalid Activity");
            }
        }

        private static void AddRunActivity(ActivityType activityType)
        {
            //AddRunActivity;
        }

        private static void AddSwimActivity(ActivityType activityType)
        {
            //AddSwimActivity;
        }

        private static void AddClimbingActivity(ActivityType activityType)
        {
            //AddClimbingActivity();
        }

        private static void AddBikeActivity(ActivityType activityType)
        {
            Console.Write("Enter Distance in Km: ");
            string? distanceInput = Console.ReadLine();
            double distance = double.Parse(distanceInput);

            Console.Write("Enter time taken in hh:mm:ss: ");
            string? timeSpanInput = Console.ReadLine();
            var timeTaken = TimeSpan.Parse(timeSpanInput);

            Console.Write("How did you feel after the activity?:\n1 = Bad \n2 = Ok \n3 = Good \n4 = Strong \n5 = Very Strong \nChoose a number: ");
            string? feelingInput = Console.ReadLine();
            var feeling = (Feeling)int.Parse(feelingInput);

            var runActivity = new RunActivity(distance*1000, timeTaken, feeling);

            ActivityRepository.Add(runActivity);
            
            Console.WriteLine("New Activity created!\n\n");
        }

        public static void ViewAllActivities()
        {
            var allActivities = ActivityRepository.GetAll();

            foreach (var activity in allActivities)
            {
                Console.WriteLine($"Distance: {activity.Distance}, Time taken in hh:mm:ss {activity.TimeTaken}, " +
                                  $"Average Speed in Km/h {activity.CalculateAverageInKmPerHour()}, Feeling {activity.Feeling}" );
            }
        }
    }
}
