using Microsoft.Data.Sqlite;
using Dapper;
using Spectre.Console;
using Microsoft.Extensions.Configuration;


public class Program
{
    internal static IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();
    
    static string? connectionString = config.GetConnectionString("DefaultConnection");

    static void Main(string[] args)
    {
        using (var connection = new SqliteConnection(connectionString))
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
    
    internal static async Task MainMenu()
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
                Console.WriteLine("Currently under construction. Pick a different option.");
                
               
                
           
                //Add a weekly goal tracker here. Class that makes a goal, and runs a prompt for time in the last week ran.?
                break;

            case "5":
                DatabaseManager.DeleteRecords();
                break;


            default:
                Console.WriteLine("Invalid input. Please take a close look at the options, and try again.");
                break;
        }
        
    }
}
