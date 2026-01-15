using System.Data;
using System.Runtime.CompilerServices;
using Microsoft.Data.Sqlite;
using Dapper;
using Spectre.Console;


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
                                            Start_Time TEXT,
                                            End_Time TEXT,
                                            Duration TEXT)";

            tableCommand.ExecuteNonQuery();
            connection.Close();
        }
        MainMenu();
    }
    
    internal static void MainMenu()
    {
        Console.Clear();
        AnsiConsole.MarkupLine("[bold purple]Welcome to David's Coding tracker![/] \n[yellow]Select the option that you need by typing the corresponding number.[/]");
        AnsiConsole.MarkupLine("[bold red]0. Quit[/]");
        AnsiConsole.MarkupLine("[green]1. Start a live coding session[/]");
        AnsiConsole.MarkupLine("[green]2. Input a historical coding session[/]");
        AnsiConsole.MarkupLine("[yellow]3. View History[/]");
        AnsiConsole.MarkupLine("[yellow]4. Set a coding goal[/]");
        AnsiConsole.MarkupLine("[maroon]5. Delete a record[/]");
        

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
                ManualCodingSession.ManualSession();
                break;

            case "3":
                DatabaseManager.ViewRecords();
                break;
            case "4":
                break;

            case "5":
                DatabaseManager.DeleteRecords();
                break;


            default:
                Console.WriteLine("Invalid input. Please take a close look at the options, and try again.");
                break;
        }
        //Need more but not 100% sure what yet.
    }
}
