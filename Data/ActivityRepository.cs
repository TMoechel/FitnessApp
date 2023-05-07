using FitnessApp.Activity;
using System.Text;

namespace FitnessApp.Data
{
    internal class ActivityRepository
    {
        private static string directoryPath = @"C:\Data\FitnessData\";
        private static string fileName = "Activities.txt";

        private static readonly List<ISportActivity> _activityList = new ();

        public static void Add(ISportActivity sportActivity)
        {
            _activityList.Add(sportActivity);
            SaveActivities();
        }

        public static List<ISportActivity> GetAllActivities()
        {
            LoadActivities();
            return _activityList;
        }

        public List<SportActivity> GetActivitiesByDate(DateTime dateOfActivity)
        {
            List<SportActivity> activitiesByDate = new List<SportActivity>();
            foreach (SportActivity activity in _activityList)
            {
                if (activity.ActivityDate.Date == dateOfActivity.Date)
                {
                    activitiesByDate.Add(activity);
                }
            }
            return activitiesByDate;
        }

        private static void LoadActivities()
        {
            string filePath = $"{directoryPath}{fileName}";
            _activityList.Clear();
            try
            {
                if (File.Exists(filePath))
                {
                    string[] sportActivitiesAsString = File.ReadAllLines(filePath);
                    if (sportActivitiesAsString.Length == 0) return;
                    for (int i = 0; i < sportActivitiesAsString.Length; i++)
                    {
                        string[] sportActivitiesSplits = sportActivitiesAsString[i].Split(';');
                        string activityName = GetFileActivityData(sportActivitiesSplits,0);
                        double distanceValue = double.Parse(GetFileActivityData(sportActivitiesSplits,1));
                        string distanceUnit = GetFileActivityData(sportActivitiesSplits, 2);
                        TimeSpan timeTaken = TimeSpan.Parse(GetFileActivityData(sportActivitiesSplits, 3));
                        double AverageSpeedValue = double.Parse(GetFileActivityData(sportActivitiesSplits, 4));
                        string averageSpeedUnit = GetFileActivityData(sportActivitiesSplits, 5);
                        string feelingFromFile = GetFileActivityData(sportActivitiesSplits, 6);
                        Feeling feeling = (Feeling)Enum.Parse(typeof(Feeling), feelingFromFile);
                        int[] heartRates = ConvertIntArrayToString(GetFileActivityData(sportActivitiesSplits, 7));
                        DateTime activityDate = DateTime.Parse(GetFileActivityData(sportActivitiesSplits, 8));

                        SportActivity sportActivity = null;

                        switch (activityName)
                        {
                            case nameof(BikeActivity):
                                sportActivity = new BikeActivity(activityDate, distanceValue, timeTaken, feeling);
                                break;
                            case nameof(ClimbActivity):
                                sportActivity = new ClimbActivity(activityDate, distanceValue, timeTaken, feeling);
                                break;
                            case nameof(SwimActivity):
                                sportActivity = new SwimActivity(activityDate, distanceValue, timeTaken, feeling);
                                break;
                            case nameof(RunActivity):
                                sportActivity = new RunActivity(activityDate, distanceValue, timeTaken, feeling);
                                break;
                        }
                        _activityList.Add(sportActivity);
                    }
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

        private static int[] ConvertIntArrayToString(string intArrayAsString)
        {
            int[] result = new int[intArrayAsString.Length];
            string[] intsAsString = intArrayAsString.Split('#');

            for (int i = 0; i < intsAsString.Length;i++)
            {
                result[i] = Convert.ToInt32(intsAsString[i]);
            }
            return result;
        }

        private static string GetFileActivityData(string[] sportActivitiesSplits, int index)
        {
            return sportActivitiesSplits[index].Substring(sportActivitiesSplits[index].IndexOf(':') + 1);
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

            foreach (var sportActivity in _activityList)
            {
                activitySB.Append($"ActivityName:{sportActivity.GetType().Name};");
                activitySB.Append($"DistanceValue:{sportActivity.Distance};");
                activitySB.Append($"DistanceUnit:{sportActivity.DistanceUnit};");
                activitySB.Append($"TimeTaken:{sportActivity.TimeTaken};");
                activitySB.Append($"AverageSpeedValue:{sportActivity.CalculateAverageSpeed()};");
                activitySB.Append($"AverageSpeedUnit:{sportActivity.GetVelocityUnit()};");
                activitySB.Append($"Feeling:{sportActivity.Feeling};");
                activitySB.Append($"HeartRate:{sportActivity.GetHeartRates()};");

                activitySB.Append($"Date:{sportActivity.ActivityDate};");
                activitySB.Append(Environment.NewLine);
            }
            
            File.WriteAllText(path, activitySB.ToString());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saved Activity successfully");
            Console.ResetColor();
            Console.WriteLine("Press ENTER to continue \n");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { };
            Console.Clear();
        }

        private static string getHeartRateStringList(int[] heartRate)
        {
            throw new NotImplementedException();
        }
    }
}
