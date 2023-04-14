using FitnessApp.Activity;
using FitnessApp.Data;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace FitnessApp.UI
{
    public class ActivityDialog
    {
        private static ActivityType[] validActivities = { ActivityType.Biking, ActivityType.Climbing, ActivityType.Running, ActivityType.Swimming };

        private const string BikeActivityName = "Biking";
        private const string SwimActivityName = "Swimming";
        private const string RunActivityName = "Running";
        private const string ClimbActivityName = "Climbing";

        private static string directoryPath = @"D:\FitnessApp\Data";
        private static string fileName = "Activity.txt";

        public static void EnterActivity()
        {
            Console.WriteLine("\n");
            Console.WriteLine("What type of sportActivity do you want to enter?");
            Console.WriteLine("1. Bike SportActivity\n2. Climb SportActivity\n3. Run SportActivity\n4. Swim SportActivity");
            Console.Write("Your selection: ");

            string? activityTypeInput = Console.ReadLine();
            try
            {
                if (activityTypeInput == null)
                {
                    throw new NullReferenceException("Activity type input cannot be null!");
                }

                if (!int.TryParse(activityTypeInput, out int activityTypeNumber))
                {
                    throw new FormatException("Activity type input must be a valid integer!");
                }

                ActivityType activityType = (ActivityType)activityTypeNumber;

                if (!validActivities.Contains(activityType))
                {
                    throw new ArgumentOutOfRangeException("Type of Sport Activity", "Invalid sportActivity!");
                }

                OpenActivityDialog(activityType);
                Console.WriteLine("New SportActivity created!\n\n");

                Console.WriteLine("Press ENTER to continue \n");
                while (Console.ReadKey().Key != ConsoleKey.Enter) { };
                Console.Clear();
            }
            catch (FormatException fx)
            {
                Console.WriteLine($"Error: {fx.Message}");
            }
            catch (NullReferenceException nrex)
            {
                Console.WriteLine($"Error: {nrex.Message}");
            }
            catch (ArgumentOutOfRangeException aoorex)
            {
                Console.WriteLine($"Error: {aoorex.Message}");
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
            try
            {
                Console.Write("Enter date of the activity in dd/mm/yyyy: ");
                string dateInput = Console.ReadLine();
                DateTime dateOfTheActivity;
                if (!DateTime.TryParse(dateInput, out dateOfTheActivity))
                {
                    throw new FormatException("Invalid date format!");
                }
                if (dateOfTheActivity > DateTime.Today)
                {
                    throw new ArgumentOutOfRangeException("dateOfTheActivity", "Activity date cannot be in the future!");
                }

                Console.Write("Enter Distance in km: ");
                string distanceInput = Console.ReadLine();
                double distance;
                if (!double.TryParse(distanceInput, out distance))
                {
                    throw new FormatException("Invalid distance format!");
                }

                Console.Write("Enter time taken in hh:mm:ss: ");
                string timeSpanInput = Console.ReadLine();
                TimeSpan timeTaken;
                if (!TimeSpan.TryParse(timeSpanInput, out timeTaken))
                {
                    throw new FormatException("Invalid time taken format!");
                }

                Console.Write("How did you feel after Running?:\n1 = Bad \n2 = Ok \n3 = Good \n4 = Strong \n5 = Very Strong \nChoose a number: ");
                string? feelingInput = Console.ReadLine();
                if (feelingInput == null)
                {
                    throw new NullReferenceException("Feeling input cannot be null!");
                }
                Feeling feeling = (Feeling)Enum.Parse(typeof(Feeling), feelingInput);

                var runActivity = new RunActivity(dateOfTheActivity, distance * 1000, timeTaken, feeling);

                ActivityRepository.Add(runActivity);
            }
            catch (FormatException fex)
            {
                Console.WriteLine($"Error: {fex.Message}");
            }
            catch (NullReferenceException nfex)
            {
                Console.WriteLine($"Error: {nfex.Message}");
            }
            catch (ArgumentOutOfRangeException aoorex)
            {
                Console.WriteLine($"Error: {aoorex.Message}");
            }
        }

        private static void AddSwimActivity(ActivityType activityType)
        {
            try
            {
                Console.Write("Enter date of the activity in dd/mm/yyyy: ");
                string dateInput = Console.ReadLine();
                DateTime dateOfTheActivity;
                if (!DateTime.TryParse(dateInput, out dateOfTheActivity))
                {
                    throw new FormatException("Invalid date format!");
                }
                if (dateOfTheActivity > DateTime.Today)
                {
                    throw new ArgumentOutOfRangeException("dateOfTheActivity", "Activity date cannot be in the future!");
                }

                Console.Write("Enter Distance you swam in meters: ");
                string distanceInput = Console.ReadLine();
                double distance;
                if (!double.TryParse(distanceInput, out distance))
                {
                    throw new FormatException("Invalid distance format!");
                }

                Console.Write("Enter time taken in hh:mm:ss: ");
                string timeSpanInput = Console.ReadLine();
                TimeSpan timeTaken;
                if (!TimeSpan.TryParse(timeSpanInput, out timeTaken))
                {
                    throw new FormatException("Invalid time taken format!");
                }

                Console.Write("How did you feel after Swimming?:\n1 = Bad \n2 = Ok \n3 = Good \n4 = Strong \n5 = Very Strong \nChoose a number: ");
                string? feelingInput = Console.ReadLine();
                if (feelingInput == null)
                {
                    throw new NullReferenceException("Feeling input cannot be null!");
                }
                Feeling feeling = (Feeling)Enum.Parse(typeof(Feeling), feelingInput);

                var swimActivity = new SwimActivity(dateOfTheActivity, distance * 1000, timeTaken, feeling);

                ActivityRepository.Add(swimActivity);
            }
            catch (FormatException fex)
            {
                Console.WriteLine($"Error: {fex.Message}");
            }
            catch (NullReferenceException nrex)
            {
                Console.WriteLine($"Error: {nrex.Message}");
            }
            catch (ArgumentOutOfRangeException aoorex)
            {
                Console.WriteLine($"Error: {aoorex.Message}");
            }
        }


        private static void AddClimbingActivity(ActivityType activityType)
        {
            try
            {
                Console.Write("Enter date of the activity in dd/mm/yyyy: ");
                string dateInput = Console.ReadLine();
                DateTime dateOfTheActivity;
                if (!DateTime.TryParse(dateInput, out dateOfTheActivity))
                {
                    throw new FormatException("Invalid date format!");
                }
                if (dateOfTheActivity > DateTime.Today)
                {
                    throw new ArgumentOutOfRangeException("dateOfTheActivity", "Activity date cannot be in the future!");
                }

                Console.Write("Enter Distance you climbed in meters: ");
                string distanceInput = Console.ReadLine();
                double distance;
                if (!double.TryParse(distanceInput, out distance))
                {
                    throw new FormatException("Invalid distance format!");
                }

                Console.Write("Enter time taken in hh:mm:ss: ");
                string timeSpanInput = Console.ReadLine();
                TimeSpan timeTaken;
                if (!TimeSpan.TryParse(timeSpanInput, out timeTaken))
                {
                    throw new FormatException("Invalid time taken format!");
                }

                Console.Write("How did you feel after Climbing?:\n1 = Bad \n2 = Ok \n3 = Good \n4 = Strong \n5 = Very Strong \nChoose a number: ");
                string? feelingInput = Console.ReadLine();
                if (feelingInput == null)
                {
                    throw new NullReferenceException("Feeling input cannot be null!");
                }
                Feeling feeling = (Feeling)Enum.Parse(typeof(Feeling), feelingInput);

                var climbActivity = new ClimbActivity(dateOfTheActivity, distance * 1000, timeTaken, feeling);

                ActivityRepository.Add(climbActivity);
            }
            catch (FormatException fex)
            {
                Console.WriteLine($"Error: {fex.Message}");
            }
            catch (NullReferenceException nrex)
            {
                Console.WriteLine($"Error: {nrex.Message}");
            }
            catch (ArgumentOutOfRangeException aoorex)
            {
                Console.WriteLine($"Error: {aoorex.Message}");
            }
        }


        private static void AddBikeActivity(ActivityType activityType)
        {
            try
            {
                Console.Write("Enter date of the activity in dd/mm/yyyy: ");
                string dateInput = Console.ReadLine();
                if (!DateTime.TryParse(dateInput, out DateTime dateOfTheActivity))
                {
                    throw new FormatException("Invalid date format!");
                }
                if (dateOfTheActivity > DateTime.Today)
                {
                    throw new ArgumentOutOfRangeException("dateOfTheActivity", "Activity date cannot be in the future!");
                }

                Console.Write("Enter Distance in km: ");
                string distanceInput = Console.ReadLine();
                if (!double.TryParse(distanceInput, out double distance) || distance < 0)
                {
                    throw new FormatException("Invalid distance format!");
                }

                Console.Write("Enter time taken in hh:mm:ss: ");
                string timeSpanInput = Console.ReadLine();
                if (!TimeSpan.TryParse(timeSpanInput, out TimeSpan timeTaken) || timeTaken < TimeSpan.Zero)
                {
                    throw new FormatException("Invalid time taken format!");
                }

                Console.Write("How did you feel after Biking?:\n1 = Bad \n2 = Ok \n3 = Good \n4 = Strong \n5 = Very Strong \nChoose a number: ");
                string feelingInput = Console.ReadLine();
                if (!Enum.TryParse<Feeling>(feelingInput, out Feeling feeling))
                {
                    throw new FormatException("Invalid feeling format!");
                }

                var bikeActivity = new BikeActivity(dateOfTheActivity, distance * 1000, timeTaken, feeling);

                ActivityRepository.Add(bikeActivity);
            }
            catch (FormatException fex)
            {
                Console.WriteLine($"Error: {fex.Message}");
            }
            catch (NullReferenceException nrex)
            {
                Console.WriteLine($"Error: {nrex.Message}");
            }
            catch (ArgumentOutOfRangeException aoorex)
            {
                Console.WriteLine($"Error: {aoorex.Message}");
            }
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

        public static void DisplayAllActivities()
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
                    Console.WriteLine($"Activity Name: {GetActivityName(activity)}");
                    Console.WriteLine($"Distance: {activity.Distance}");
                    Console.WriteLine($"Time: {activity.TimeTaken}");
                    Console.WriteLine($"Average Speed: {activity.CalculateAverageSpeed() + " " + activity.ShowKmM()}");
                    Console.WriteLine($"Feeling: {activity.Feeling}");
                    Console.WriteLine($"Date: {activity.ActivityDate}\n");
                }

            Console.WriteLine("Press ENTER to continue \n");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { };
            Console.Clear();
        }

        public static void LoadSpecificActivityByDate()
        {
            try
            {
                Console.Write("Enter the Date of the SportActivity in the Format dd/mm/yyyy like 12/06/2021: ");
                string dateOfActivityInput = Console.ReadLine();
                DateTime dateOfActivity;
                if (!DateTime.TryParse(dateOfActivityInput, out dateOfActivity))
                {
                    throw new FormatException("Invalid date format!");
                }

                ActivityRepository repo = new ActivityRepository();

                List<SportActivity> activities = repo.GetActivitiesByDate(dateOfActivity);

                Console.WriteLine($"\nActivities on {dateOfActivity.ToShortDateString()}:");
                foreach (var activity in activities)
                {
                    Console.WriteLine($"Activity Name: {GetActivityName(activity)}");
                    Console.WriteLine($"Distance: {activity.Distance} meters");
                    Console.WriteLine($"Time: {activity.TimeTaken}");
                    Console.WriteLine($"Average Speed: {activity.CalculateAverageSpeed() + " " + activity.ShowKmM()}");
                    Console.WriteLine($"Feeling: {activity.Feeling}");
                    Console.WriteLine($"Date: {activity.ActivityDate}\n");
                }
            }
            catch (FormatException fex)
            {
                Console.WriteLine($"Error: {fex.Message}");
            }

            Console.WriteLine("Press ENTER to continue \n");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { };
            Console.Clear();
        }

        public static void CheckForExistingActivityFile()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            string path = $"{directoryPath}{fileName}";

            bool activityFileFound = File.Exists(path);

            if (activityFileFound)
            {
                Console.WriteLine("An existing file with Activity data is found.");
            }
            else
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(directoryPath);
                Console.WriteLine("Directory is ready for saving files.");
            }
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        public static void SaveActivities()
        {
            string path = $"{directoryPath}{fileName}";
            StringBuilder activitySB = new StringBuilder();

            var allActivities = ActivityRepository.GetAll();

            foreach (var sportactivity in allActivities)
            {
                activitySB.Append($"ActivityName:{GetActivityName(sportactivity)};");
                activitySB.Append($"Distance:{sportactivity.Distance} meters");
                activitySB.Append($"TimeTaken:{sportactivity.TimeTaken};");
                activitySB.Append($"AverageSpeed:{sportactivity.CalculateAverageSpeed()} {sportactivity.ShowKmM()};");
                activitySB.Append($"Feeling:{sportactivity.Feeling};");
                activitySB.Append($"Date:{sportactivity.ActivityDate.ToString()};");
                activitySB.Append(Environment.NewLine);
            }

            File.WriteAllText(path, activitySB.ToString());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saved Activities successfully");
            Console.ResetColor();
            Console.WriteLine("Press ENTER to continue \n");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { };
            Console.Clear();
        }

        public static void LoadActivities(List<SportActivity> sportActivities)
        {
            string filePath = $"{directoryPath}{fileName}";
            try
            {
                if (File.Exists(filePath))
                {
                    sportActivities.Clear();

                    string[] sportActivitiesAsString = File.ReadAllLines(filePath);
                    for (int i = 0; i < sportActivitiesAsString.Length; i++)
                    {
                        string[] sportActivitiesSplits = sportActivitiesAsString[i].Split(';');
                        string activityName = sportActivitiesSplits[0].Substring(sportActivitiesSplits[0].IndexOf(':') + 1);
                        double distance = double.Parse(sportActivitiesSplits[1].Substring(sportActivitiesSplits[1].IndexOf(':') + 1));
                        TimeSpan timeTaken = TimeSpan.Parse(sportActivitiesSplits[2].Substring(sportActivitiesSplits[2].IndexOf(':') + 1));
                        double averageSpeed = double.Parse(sportActivitiesSplits[3].Substring(sportActivitiesSplits[3].IndexOf(':') + 1));
                        string feelingFromFile = sportActivitiesSplits[4].Substring(sportActivitiesSplits[4].IndexOf(':') + 1);
                        Feeling feeling = (Feeling)Enum.Parse(typeof(Feeling), feelingFromFile);
                        DateTime activityDate = DateTime.Parse(sportActivitiesSplits[5].Substring(sportActivitiesSplits[5].IndexOf(':') + 1));

                        SportActivity sportActivity = null;

                        switch (activityName)
                        {
                            case nameof(BikeActivity):
                                sportActivity = new BikeActivity(activityDate, distance, timeTaken, feeling);
                                break;
                            case nameof(ClimbActivity):
                                sportActivity = new ClimbActivity(activityDate, distance, timeTaken, feeling);
                                break;
                            case nameof(SwimActivity):
                                sportActivity = new SwimActivity(activityDate, distance, timeTaken, feeling);
                                break;
                            case nameof(RunActivity):
                                sportActivity = new RunActivity(activityDate, distance, timeTaken, feeling);
                                break;
                        }


                        sportActivities.Add(sportActivity);

                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Loaded {sportActivities.Count} activities!\n");
                    Console.WriteLine("Press ENTER to continue \n");
                    while (Console.ReadKey().Key != ConsoleKey.Enter) { };
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Activity file not found. No activities loaded.");
                    Console.WriteLine("Press ENTER to continue \n");
                    while (Console.ReadKey().Key != ConsoleKey.Enter) { };
                    Console.Clear();
                }
            }
            catch (IndexOutOfRangeException iex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong parsing the file, please check the data!");
                Console.WriteLine(iex.Message);
            }
            catch (FileNotFoundException fnfex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The file couldn't be found!");
                Console.WriteLine(fnfex.Message);
                Console.WriteLine(fnfex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong while loading the file!");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ResetColor();
            }
        }
    }
}
