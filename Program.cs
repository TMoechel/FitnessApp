using FitnessApp;
using FitnessApp.Activity;

List<Activity> activities = new List<Activity>();
string userSelection;
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

    Console.WriteLine("1: Enter new activity");
    Console.WriteLine("2: View all activities");
    Console.WriteLine("3: Load specific activity");
    Console.WriteLine("9: Quit application");
    Console.Write("Your selection: ");

    userSelection = Console.ReadLine();

    switch (userSelection)
    {
        case "1":
            Activity.EnterActivity(activities);
            break;
        case "2":
            Activity.ViewAllActivities(activities);
            break;
        case "3":
            Activity.LoadActivity(activities);
            break;
        case "9": break;
        default:
            Console.WriteLine("Invalid selection. Please try again.");
            break;
            Console.Clear();
    }
}
while (userSelection != "9");

Console.WriteLine("Thanks for using Loropio Fitness App");


