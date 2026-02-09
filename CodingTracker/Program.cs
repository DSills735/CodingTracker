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
        var connection = new SqliteConnection(connectionString);

        var tableCreate = SqlHelper.TableCreate();

        connection.Execute(tableCreate);
        
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
        AnsiConsole.MarkupLine("[yellow]4. Set a coding goal[/] - [maroon]Not yet functional, do NOT use.[/]");
        AnsiConsole.MarkupLine("[maroon]5. Delete a record[/]");
        

        string response = Console.ReadLine()!;

        switch (response)
        {
            
            case "0":
                Environment.Exit(0);
                break;

            case "1":
                LiveSession.StartCodingSession();
                break;

            case "2":
                ManualCodingSession.ManualSession();
                break;

            case "3":
                DatabaseManager.ViewRecordsPersonal();
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
