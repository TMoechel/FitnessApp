using FitnessApp.Activity;
using FitnessApp.Data;
using System;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace FitnessApp.UI
{
    public class ActivityDialog
    {
        private static ActivityType[] validActivities = { ActivityType.BikeActivity, ActivityType.ClimbActivity, ActivityType.RunActivity, ActivityType.SwimActivity };

        public static void EnterActivity()
        {
            Console.WriteLine("\n");
            Console.WriteLine("What type of sportActivity do you want to enter?");
            Console.WriteLine("1. Bike SportActivity\n2. Climb SportActivity\n3. Run SportActivity\n4. Swim SportActivity");
            Console.Write("Your selection: ");
            
            string? activityTypeInput = Console.ReadLine();
            ActivityType activityType = ActivityType.Undefined;
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

                activityType = (ActivityType)activityTypeNumber;

                if (!validActivities.Contains(activityType))
                {
                    throw new ArgumentOutOfRangeException("Type of Sport Activity", "Invalid sportActivity!");
                }

                OpenActivityDialog(activityType);
            }
            catch (FormatException fx)
            {
                Console.WriteLine($"Error: {fx.Message}");
                throw fx;
            }
            catch (NullReferenceException nrex)
            {
                Console.WriteLine($"Error: {nrex.Message}");
                throw nrex;
            }
            catch (ArgumentOutOfRangeException aoorex)
            {
                Console.WriteLine($"Error: {aoorex.Message}");
                throw aoorex;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw ex;
            }

            
        }

        private static void OpenActivityDialog(ActivityType activityType)
        {
            switch (activityType)
            {
                case ActivityType.BikeActivity:
                    AddBikeActivity(activityType);
                    break;
                case ActivityType.ClimbActivity:
                    AddClimbingActivity(activityType);  // this is a special sportActivity with other data
                    break;
                case ActivityType.RunActivity:
                    AddRunActivity(activityType);
                    break;
                case ActivityType.SwimActivity:
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
                Console.WriteLine("New Run Activity created!\n\n");
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
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

                var swimActivity = new SwimActivity(dateOfTheActivity, distance, timeTaken, feeling);

                ActivityRepository.Add(swimActivity);
                Console.WriteLine("New Swim Activity created!\n\n");

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
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        private static void AddClimbingActivity(ActivityType activityType)
        {
            try
            {
                Console.Write("Enter date of the activity in dd/mm/yyyy: ");
                string? dateInput = Console.ReadLine();
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
                string? distanceInput = Console.ReadLine();
                double distance;
                if (!double.TryParse(distanceInput, out distance))
                {
                    throw new FormatException("Invalid distance format!");
                }

                Console.Write("Enter time taken in hh:mm:ss: ");
                string? timeSpanInput = Console.ReadLine();
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

                var climbActivity = new ClimbActivity(dateOfTheActivity, distance, timeTaken, feeling);

                ActivityRepository.Add(climbActivity);
                Console.WriteLine("New Climb Activity created!\n\n");

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
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
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
                Console.WriteLine("New Bike Activity created!\n\n");


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
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }           

        

        public static void DisplayAllActivities()
        {
            Console.WriteLine("********************");
            Console.WriteLine("* Your Activities  *");
            Console.WriteLine("********************");

            var allActivities = ActivityRepository.GetAllActivities();

            foreach (var activity in allActivities)
                {
                    Console.WriteLine($"Activity: { activity.GetType().Name}");
                    Console.WriteLine($"Distance: {activity.GetActivityDistance()} {activity.DistanceUnit}");
                    Console.WriteLine($"Time: {activity.TimeTaken}");
                    Console.WriteLine($"Average Speed: {activity.CalculateAverageSpeed() + " " + activity.GetVelocityUnit()}");
                    Console.WriteLine($"Feeling: {activity.Feeling}");
                    Console.WriteLine($"Date: {activity.ActivityDate}");
                    Console.WriteLine($"HeartRates: {activity.GetHeartRates()}\n");
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
                    Console.WriteLine($"Activity Name: {activity.ActivityName}");
                    Console.WriteLine($"Distance: {activity.Distance} meters");
                    Console.WriteLine($"Time: {activity.TimeTaken}");
                    Console.WriteLine($"Average Speed: {activity.CalculateAverageSpeed() + " " + activity.GetVelocityUnit()}");
                    Console.WriteLine($"Feeling: {activity.Feeling}");
                    Console.WriteLine($"Date: {activity.ActivityDate}\n");
                }
            }
            catch (FormatException fex)
            {
                Console.WriteLine($"Error: {fex.Message}");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Press ENTER to continue \n");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { };
            Console.Clear();
        }

        
        
    }
}
