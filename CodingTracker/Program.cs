using System.Data;
using System.Runtime.CompilerServices;
using Microsoft.Data.Sqlite;
using Dapper;


public static class Program
{
    static string connectionStr = "Data Source = codingTracker.db";
    static void Main(string[] args)
    {
        using (var connection = new SqliteConnection(connectionStr))
        {
            connection.Open();

            var tableCommand = connection.CreateCommand();
            tableCommand.CommandText = @"CREATE TABLE IF NOT EXISTS Coding_Tracker(
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Start_Time TIME,
                                            End_Time TIME,
                                            Duration TIME)";

            tableCommand.ExecuteNonQuery();
            connection.Close();
        }
        MainMenu();
    }
    
    internal static void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to David's Coding tracker! Below will be a few options. Select the option that you need by typing the corresponding number.");
        Console.WriteLine("0. Quit");
        Console.WriteLine("1. Start a coding session");
        Console.WriteLine("2. Input a coding session manually");
        Console.WriteLine("3. View History");
        Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------");


        string response = Console.ReadLine()!;

        switch (response)
        {
            //this is going to read the response from the user and send them to the right place. 
            case "0":
                Environment.Exit(0);
                break;

            case "1":
                CodingSession.StartCodingSession();
                break;

            case "2":
                break;

            case "3":
                break;

            //case "4": Not sure if needed yet


            default:
                Console.WriteLine("Invalid input. Please take a close look at the options, and try again.");
                break;
        }
        //Need more but not 100% sure what yet.
    }
}
