using Spectre.Console;
using Microsoft.Extensions.Configuration;
using Dapper;


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

    internal static void ViewRecords()
    {
        Console.Clear();
        using (var connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionStr))
        {
            connection.Open();
            var selectCommand = connection.CreateCommand();
            selectCommand.CommandText = @"SELECT * FROM Coding_Tracker";
            using (var reader = selectCommand.ExecuteReader())
            {
                var table = new Table()
                .AddColumn("[red]Session ID[/]")
                .AddColumn("[green]Start Time[/]")
                .AddColumn("[maroon]End Time[/]")
                .AddColumn("[yellow]Duration[/]");
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string startTime = reader.GetString(1);
                    string endTime = reader.GetString(2);
                    string duration = reader.GetString(3);
                    table.AddRow($"[red]{id}[/]",$"[green]{startTime}[/]", $"[maroon]{endTime}[/]",$"[yellow]{duration}[/]");
                }
                AnsiConsole.Write(table);
            }
            connection.Close(); 
        }
        AnsiConsole.MarkupLine("[maroon]Press any key to return to the main menu[/]");
        Console.ReadKey();
        Program.MainMenu();

       
    }

    internal static void DeleteRecords() 
    {
        ViewRecords();
        Console.WriteLine("Enter the ID of the record you wish to delete:");
        string id = Console.ReadLine()!;

        using (var connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionStr))
        {
            connection.Open();
            var deleteCommand = connection.CreateCommand();
            deleteCommand.CommandText = @$"DELETE FROM Coding_Tracker WHERE id = {id}";
            int rowCount = deleteCommand.ExecuteNonQuery();

            if (rowCount == 0)
            {
                Console.WriteLine($"Record with ID: {id} does not exist.");
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
            connection.Close();

            Program.MainMenu();
        }
    }
}
