using Spectre.Console;
public class DatabaseManager 
{
    static string connectionStr = "Data Source = codingTracker.db";

    internal static void AddRecordToDatabase(DateTime start, DateTime end, string duration)
    {
        using (var connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionStr))
        {
            connection.Open();
            var insertCommand = connection.CreateCommand();
            insertCommand.CommandText = @"INSERT INTO Coding_Tracker (Start_Time, End_Time, Duration) 
                                          VALUES ($startTime, $endTime, $duration)";
            insertCommand.Parameters.AddWithValue("$startTime", start.ToString("yyyy-MM-dd HH:mm:ss"));
            insertCommand.Parameters.AddWithValue("$endTime", end.ToString("yyyy-MM-dd HH:mm:ss"));
            insertCommand.Parameters.AddWithValue("$duration", duration);
            insertCommand.ExecuteNonQuery();
            connection.Close();
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
                .AddColumn("[blue]Start Time[/]")
                .AddColumn("[green]End Time[/]")
                .AddColumn("[yellow]Duration[/]");
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string startTime = reader.GetString(1);
                    string endTime = reader.GetString(2);
                    string duration = reader.GetString(3);
                    table.AddRow($"[red]{id}[/]",$"[blue]{startTime}[/]", $"[green]{endTime}[/]",$"[yellow]{duration}[/]");
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
