string userSelection;
do
{
    //print the first screen
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
}
while (userSelection != "9");


