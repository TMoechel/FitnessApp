using FitnessApp.Activity;

namespace FitnessApp.UI
{
    public static class Dialog
    {
        public static void StartDialog()
        {   
            List<SportActivity> sportActivities = new List<SportActivity>();
            
            string userSelection;

            ActivityDialog.CheckForExistingActivityFile();

            do
            {
                //print the first screen
                //this is another comment
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("**************************************");
                Console.WriteLine("* Welcome to the Loropio Fitness App *");
                Console.WriteLine("**************************************");
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("********************");
                Console.WriteLine("* Select an action *");
                Console.WriteLine("********************");

                Console.WriteLine("1: Enter new sportActivity");
                Console.WriteLine("2: View all activities");
                Console.WriteLine("3: Save Activities");
                Console.WriteLine("4: Load specific sportActivity");
                Console.WriteLine("9: Quit application");
                Console.Write("Your selection: ");

                userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        ActivityDialog.EnterActivity();
                        break;
                    case "2":
                        ActivityDialog.DisplayAllActivities();
                        break;
                    case "3":
                        ActivityDialog.SaveActivities(sportActivities);
                        break;
                    case "4":
                        ActivityDialog.LoadSpecificActivitiesForDay();
                        break;
                    case "9": break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
            while (userSelection != "9");

            Console.WriteLine("Thanks for using Loropio Fitness App");
        }
    }
}
