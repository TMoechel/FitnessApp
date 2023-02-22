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

        public Activity(double distance, double timeTaken, string feeling)
        {
            Distance = distance;
            TimeTaken = timeTaken;
        }

        public double CalculateAverage => averageSpeed = Distance / TimeTaken;

        internal static void EnterActivity(List<Activity> activities)
        {
            Console.WriteLine("What type of activity do you want to enter?");
            Console.WriteLine("1. Bike Activity\n2. Climb Activity\n3. Run Activity\n4. Swim Activity");
            Console.Write("Your selection: ");
            string activityTypeInput = Console.ReadLine();
            int activityType = int.Parse(activityTypeInput);
            SportsType sportstype = (SportsType)(activityType-1);

            if (activityTypeInput != "1" && activityTypeInput != "2" && activityTypeInput != "3"
                && activityTypeInput != "4" && activityTypeInput != "5")
            {
                Console.WriteLine("Invalid activity!");
                return;
            }

            Console.Write("Enter Distance: ");
            string distance = Console.ReadLine();
            double distanceInputToDouble = double.Parse(distance);

            Console.Write("Enter time taken: ");
            string time = Console.ReadLine();
            double timeInputToDouble = double.Parse(time);

            Console.Write("How did you feel after the activity?:\n1 = Bad \n2 = Ok \n3 = Good \n4 = Strong \n5 = Very Strong \nChoose a number: ");
            string feeling = Console.ReadLine();
            int feelingInputToString = int.Parse(feeling);
            Feeling f = (Feeling)(feelingInputToString - 1);

            switch (f)
            {
                case (Feeling)1:
                    f = Feeling.Bad;
                    break;
                case (Feeling)2:
                    f = Feeling.Ok;
                    break;
                case (Feeling)3:
                    f = Feeling.Good;
                    break;
                case (Feeling)4:
                    f = Feeling.Strong;
                    break;
                case (Feeling)5:
                    f = Feeling.Very_Strong;
                    break;
                default:
                    Console.WriteLine("Invalid selection");
                    break;

            }

            Activity activity = null;

            switch (activityTypeInput)
            {
                case "1":
                    activity = new BikeActivity(distanceInputToDouble, timeInputToDouble, feeling);
                    sportstype = SportsType.Biking;
                    break;
                case "2":
                    activity = new ClimbActivity(distanceInputToDouble, timeInputToDouble, feeling);
                    sportstype = SportsType.Climbing;
                    break;
                case "3":
                    activity = new RunActivity(distanceInputToDouble, timeInputToDouble, feeling);
                    sportstype = SportsType.Running;
                    break;
                case "4":
                    activity = new SwinActivity(distanceInputToDouble, timeInputToDouble, feeling);
                    sportstype = SportsType.Swimming;
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
            //here I need to display the activity the user selected and how they felt
            Console.WriteLine($"Activity:{/*Activity Display*/} \t \nDistance: \t{Distance} \nTime: \t{TimeTaken} \nFeeling:{/*feeling Display*/} \t \nAverage Speed: \t{CalculateAverage}");
        }

        internal static void LoadSpecificActivity(List<Activity> activities)
        {
            throw new NotImplementedException();
        }
    }
}