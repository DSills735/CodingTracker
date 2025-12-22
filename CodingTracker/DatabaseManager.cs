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
        using (var connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionStr))
        {
            connection.Open();
            var selectCommand = connection.CreateCommand();
            selectCommand.CommandText = @"SELECT * FROM Coding_Tracker";
            using (var reader = selectCommand.ExecuteReader())
            {
                Console.WriteLine("ID | Start Time          | End Time            | Duration");
                Console.WriteLine("--------------------------------------------------------");
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string startTime = reader.GetString(1);
                    string endTime = reader.GetString(2);
                    string duration = reader.GetString(3);
                    Console.WriteLine($"{id}  | {startTime} | {endTime} | {duration}");
                }
            }
            connection.Close();
        }
    }
}
