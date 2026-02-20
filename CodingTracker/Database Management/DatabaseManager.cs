using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Spectre.Console;


public class DatabaseManager
{ 

    static string? connectionStr = Program.config.GetConnectionString("DefaultConnection");

    internal static void AddRecordToDatabase(DateTime start, DateTime end, string duration)
    {
        using (var connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionStr))
        {   

            var session = SqlHelper.SessionCreator(start, end, duration);

            string insertCommand = SqlHelper.InsertCommand(session);

            connection.Execute(insertCommand, session);
        }
    }

    //might need to name this better, but this is intentionally for end user recordkeeping only. 
    internal static void ViewRecordsPersonal()
    {
        //string sql = SqlHelper.ViewAllCommand();
        Console.Clear(); 
        using (var connection = new SqliteConnection(connectionStr))
        {
            var sessions = connection.Query(SqlHelper.ViewAllCommand()).ToList();

            var table = new Table()
                .AddColumn("[red]Session ID[/]")
                .AddColumn("[green]Start Time[/]")
                .AddColumn("[maroon]End Time[/]")
                .AddColumn("[yellow]Duration[/]");

            foreach (var session in sessions)
            {
                table.AddRow($"[red]{session.Id}[/]", $"[green]{session.Start_Time}[/]",
                                $"[maroon]{session.End_Time}[/]", $"[yellow]{session.Duration}[/]");
            }

            AnsiConsole.Write(table);
            AnsiConsole.MarkupLine("[maroon]Press any key to return to the main menu[/]");
            Console.ReadKey();
            Program.MainMenu();


        }
    }
    //this is essentiually the same as above, but only used for delete since I have the clear console and main menu calls. 
    //Maybe find a simpler way to do this??
    internal static void ViewRecordsDelete()
    {
        using (var connection = new SqliteConnection(connectionStr))
        {
            var sessions = connection.Query(SqlHelper.ViewAllCommand()).ToList();

            var table = new Table()
                .AddColumn("[red]Session ID[/]")
                .AddColumn("[green]Start Time[/]")
                .AddColumn("[maroon]End Time[/]")
                .AddColumn("[yellow]Duration[/]");

            foreach (var session in sessions)
            {
                table.AddRow($"[red]{session.Id}[/]", $"[green]{session.Start_Time}[/]",
                                $"[maroon]{session.End_Time}[/]", $"[yellow]{session.Duration}[/]");
            }

            AnsiConsole.Write(table);
        }
    }

    internal static void DeleteRecords() 
    {
        ViewRecordsDelete();
        Console.WriteLine("Enter the ID of the record you wish to delete:");
        string id = Console.ReadLine()!;

        using (var connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionStr))
        {

            int rowCount = connection.Execute(SqlHelper.DeleteSingleRecord(), new { Id = id });

            if (rowCount == 0)
            {
                Console.WriteLine($"Record with ID: {id} does not exist.");
                Console.Clear();
                DeleteRecords();
            }
            Console.WriteLine($"Record with ID: {id} has been deleted.");

            Console.WriteLine("Delete another record? Press Y. Any other key to return to main menu.");
            string response = Console.ReadLine()!.Trim().ToLower();

            if (response == "y") 
            {
                DeleteRecords();
            }
            else
            {
                Program.MainMenu();
            }
            

            Program.MainMenu();
        }
    }
}
