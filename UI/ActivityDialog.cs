using FitnessApp.Activity;
using FitnessApp.Data;

namespace FitnessApp.UI
{
    public class ActivityDialog
    {
        private static string[] validActivities = { "1", "2", "3", "4" };

        private const string BikeActivityName = "Biking";
        private const string SwimActivityName = "Swimming";
        private const string RunActivityName = "Running";
        private const string ClimbActivityName = "Climbing";
        

        public static void EnterActivity()
        {
            Console.WriteLine("\n");
            Console.WriteLine("What type of sportActivity do you want to enter?");
            Console.WriteLine("1. Bike SportActivity\n2. Climb SportActivity\n3. Run SportActivity\n4. Swim SportActivity");
            Console.Write("Your selection: ");
            
            string? activityTypeInput = Console.ReadLine();
            if (activityTypeInput != null)
            {
                ActivityType activityType = (ActivityType)int.Parse(activityTypeInput!);

                if (!validActivities.Contains(activityTypeInput))
                {
                    Console.WriteLine("Invalid sportActivity!");
                    return;
                }

                OpenActivityDialog(activityType);
                Console.WriteLine("New SportActivity created!\n\n");
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
                    AddClimbingActivity(activityType);  // this is a special sportActivity with other data
                    break;
                case ActivityType.Running:
                    AddRunActivity(activityType);
                    break;
                case ActivityType.Swimming:
                    AddSwimActivity(activityType);
                    break;
                default: throw new ArgumentException("Invalid SportActivity");
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
            Console.Write("Enter Distance in km: ");
            string distanceInput = Console.ReadLine();
            double distance = double.Parse(distanceInput);

            Console.Write("Enter time taken in hh:mm:ss: ");
            string timeSpanInput = Console.ReadLine();
            TimeSpan timeTaken = TimeSpan.Parse(timeSpanInput);

            Console.Write("How did you feel after the sportActivity?:\n1 = Bad \n2 = Ok \n3 = Good \n4 = Strong \n5 = Very Strong \nChoose a number: ");
            string? feelingInput = Console.ReadLine();
            Feeling feeling = (Feeling) Enum.Parse(typeof(Feeling), feelingInput);

            var bikeActivity = new BikeActivity(distance*1000, timeTaken, feeling);

            ActivityRepository.Add(bikeActivity);
        }

        public static void ViewAllActivities()
        {
            Console.WriteLine("********************");
            Console.WriteLine("* Your Activities  *");
            Console.WriteLine("********************");

            var allActivities = ActivityRepository.GetAll();
            
            if (!allActivities.Any())
            {
                Console.WriteLine("No Sport Activities yet recorded");
            }
            else foreach (var activity in allActivities)
            {
                Console.WriteLine($"Activity: {GetActivityName(activity)}, Distance: {activity.Distance} m, Time taken: {activity.TimeTaken} hh:mm:ss, " +
                                  $"Average Speed: {activity.CalculateAverageInKmPerHour()} km/h, Feeling: {activity.Feeling}" );
            }

            Console.WriteLine("Press ENTER to continue \n");
            while (Console.ReadKey().Key != ConsoleKey.Enter){};
        }

        private static string GetActivityName(ISportActivity activity)
        {
            var activityClassName = activity.GetType().Name;    
            switch (activityClassName)
            {
                case nameof(BikeActivity):
                {
                    return BikeActivityName;
                }
                case nameof(SwimActivity):
                {
                    return SwimActivityName;
                }
                case nameof(ClimbActivity):
                {
                    return ClimbActivityName;
                }
                case nameof(RunActivity):
                {
                    return RunActivityName;
                }
            }
            return string.Empty;
        }

        public static void LoadSpecificActivitiesForDay()
        {
            Console.Write("Enter the Date of the SportActivity in the Format dd..mm.yyyy like 12.06.2021");
            string dateOfActivityInput = Console.ReadLine();
            DateTime dateOfActivity = DateTime.Parse(dateOfActivityInput);

            //todo: load activities by date from repository
        }
    }
}
