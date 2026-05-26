
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

internal class LiveSession
{
    static string? connectionStr = Program.config.GetConnectionString("DefaultConnection");
    internal static void StartCodingSession()
    {
        DateTime start;
        DateTime end;
        Console.Clear();
        Console.WriteLine(@"You are starting a new coding session, when you are ready to start 
                                press 1. If you would like to exit to the main menu, press Q.");
        string response = Console.ReadLine()!;

        if (response == "1")
        {
            bool validInput = false;
            start = DateTime.Now;
            Console.WriteLine($"You have begun your coding session at {start}. Dont forget the \";\"!");
            Console.WriteLine();
            Console.WriteLine("When you finish this session, please enter \"1\"");
            string userInput = Console.ReadLine()!;
            while (!validInput)
            {

                if (userInput == "1")
                {
                    validInput = true;
                    end = DateTime.Now;
                    Console.WriteLine($"You finished your coding session at {end}. Calculating duration now...");
                    TimeSpan duration = CalculateDuration.CalculateTimeDuration(start, end);

                    string timeSpentCoding = CalculateDuration.TimeFormatter(duration);

                    Console.WriteLine($"You coded for a total of {timeSpentCoding}. Great work!");
                    var connection = new SqliteConnection(connectionStr);
                    connection.Open();
                    DatabaseManager.AddRecordToDatabase(start, end, timeSpentCoding, connection);
                    connection.Close();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 1 if you wish to finish.");
                    userInput = Console.ReadLine()!;
                }
            }
            Console.WriteLine("Do you wish to return to the main menu? Press Y. If you wish to exit press any other key.");
            userInput = Console.ReadLine()!;

            if (userInput.Trim().ToLower() == "y")
            {
                Program.MainMenu();
            }
            else
            {
                Environment.Exit(0);
            }
        }
        else if (response.Trim().ToLower() == "q")
        {
            Program.MainMenu();

        }
        else
        {
            Console.WriteLine("Invalid Input, please try again.");
            StartCodingSession();
        }
    }
}

