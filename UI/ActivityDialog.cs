﻿using FitnessApp.Activity;
using FitnessApp.Data;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace FitnessApp.UI
{
    public class ActivityDialog
    {
        private static string[] validActivities = { "1", "2", "3", "4" };

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
            Console.Write("Enter date of the activity in dd/mm/yyyy: ");
            string dateInput = Console.ReadLine();
            DateTime dateOfTheActivity = DateTime.Parse(dateInput);

            Console.Write("Enter Distance in km: ");
            string distanceInput = Console.ReadLine();
            double distance = double.Parse(distanceInput);

            Console.Write("Enter time taken in hh:mm:ss: ");
            string timeSpanInput = Console.ReadLine();
            TimeSpan timeTaken = TimeSpan.Parse(timeSpanInput);

            Console.Write("How did you feel after Running?:\n1 = Bad \n2 = Ok \n3 = Good \n4 = Strong \n5 = Very Strong \nChoose a number: ");
            string? feelingInput = Console.ReadLine();
            Feeling feeling = (Feeling)Enum.Parse(typeof(Feeling), feelingInput);

            var runActivity = new RunActivity(dateOfTheActivity, distance * 1000, timeTaken, feeling);

            ActivityRepository.Add(runActivity);
        }

        private static void AddSwimActivity(ActivityType activityType)
        {
            Console.Write("Enter date of the activity in dd/mm/yyyy: ");
            string dateInput = Console.ReadLine();
            DateTime dateOfTheActivity = DateTime.Parse(dateInput);

            Console.Write("Enter Distance you swam in meters: ");
            string distanceInput = Console.ReadLine();
            double distance = double.Parse(distanceInput);

            Console.Write("Enter time taken in hh:mm:ss: ");
            string timeSpanInput = Console.ReadLine();
            TimeSpan timeTaken = TimeSpan.Parse(timeSpanInput);

            Console.Write("How did you feel after Swimming?:\n1 = Bad \n2 = Ok \n3 = Good \n4 = Strong \n5 = Very Strong \nChoose a number: ");
            string? feelingInput = Console.ReadLine();
            Feeling feeling = (Feeling)Enum.Parse(typeof(Feeling), feelingInput);

            var swimActivity = new SwimActivity(dateOfTheActivity, distance, timeTaken, feeling);

            ActivityRepository.Add(swimActivity);
        }

        private static void AddClimbingActivity(ActivityType activityType)
        {
            Console.Write("Enter date of the activity in dd/mm/yyyy: ");
            string dateInput = Console.ReadLine();
            DateTime dateOfTheActivity = DateTime.Parse(dateInput);

            Console.Write("Enter Distance you climbed in meters: ");
            string distanceInput = Console.ReadLine();
            double distance = double.Parse(distanceInput);

            Console.Write("Enter time taken in hh:mm:ss: ");
            string timeSpanInput = Console.ReadLine();
            TimeSpan timeTaken = TimeSpan.Parse(timeSpanInput);

            Console.Write("How did you feel after Climbing?:\n1 = Bad \n2 = Ok \n3 = Good \n4 = Strong \n5 = Very Strong \nChoose a number: ");
            string? feelingInput = Console.ReadLine();
            Feeling feeling = (Feeling)Enum.Parse(typeof(Feeling), feelingInput);

            var climbingActivity = new ClimbActivity(dateOfTheActivity, distance, timeTaken, feeling);

            ActivityRepository.Add(climbingActivity);
        }

        private static void AddBikeActivity(ActivityType activityType)
        {
            Console.Write("Enter date of the activity in dd/mm/yyyy: ");
            string dateInput = Console.ReadLine();
            DateTime dateOfTheActivity = DateTime.Parse(dateInput);

            Console.Write("Enter Distance in km: ");
            string distanceInput = Console.ReadLine();
            double distance = double.Parse(distanceInput);

            Console.Write("Enter time taken in hh:mm:ss: ");
            string timeSpanInput = Console.ReadLine();
            TimeSpan timeTaken = TimeSpan.Parse(timeSpanInput);

            Console.Write("How did you feel after the sportActivity?:\n1 = Bad \n2 = Ok \n3 = Good \n4 = Strong \n5 = Very Strong \nChoose a number: ");
            string? feelingInput = Console.ReadLine();
            Feeling feeling = (Feeling) Enum.Parse(typeof(Feeling), feelingInput);

            var bikeActivity = new BikeActivity(dateOfTheActivity, distance *1000, timeTaken, feeling);

            ActivityRepository.Add(bikeActivity);
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
                    Console.WriteLine($"Activity: {GetActivityName(activity)}, Distance: {activity.Distance} m, Time taken: {activity.TimeTaken} hh:mm:ss, " +
                                      $"Average Speed: {activity.CalculateAverageSpeed()} {activity.ShowKmM()}, Feeling: {activity.Feeling}, Date: {activity.ActivityDate}");
                }

            Console.WriteLine("Press ENTER to continue \n");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { };
            Console.Clear();
        }

        public static void LoadSpecificActivityByDate()
        {
            Console.Write("Enter the Date of the SportActivity in the Format dd.mm.yyyy like 12/06/2021: ");
            string dateOfActivityInput = Console.ReadLine();
            DateTime dateOfActivity = DateTime.Parse(dateOfActivityInput);

            //todo: load activities by date from repository
            ActivityRepository repo = new ActivityRepository(); 
            List<SportActivity> activities = repo.GetActivitiesByDate(dateOfActivity);

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
                activitySB.Append($"Distance:{sportactivity.Distance};");
                activitySB.Append($"TimeTaken:{sportactivity.TimeTaken};");
                activitySB.Append($"AverageSpeed:{sportactivity.CalculateAverageSpeed()};");
                activitySB.Append($"Feeling:{sportactivity.Feeling};");
                activitySB.Append($"Date:{sportactivity.ActivityDate};");
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
    }
}
