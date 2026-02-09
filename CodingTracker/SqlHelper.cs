using Dapper;
internal class SqlHelper
{
    public static string TableCreate()
    {
        return @"CREATE TABLE IF NOT EXISTS Coding_Tracker(
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Start_Time TEXT,
                                            End_Time TEXT,
                                            Duration TEXT)";
    }

    public static CodingSession SessionCreator(DateTime start, DateTime end, string duration)
    {

        string startTime = start.ToString("yyyy-MM-dd HH:mm:ss");
        string endTime = end.ToString("yyyy-MM-dd HH:mm:ss");

        return new CodingSession() { Start_Time = startTime, End_Time = endTime, Duration = duration };

    }
    public static string InsertCommand(CodingSession session)
    {
        return @"INSERT INTO Coding_Tracker (Start_Time, End_Time, Duration)
                       VALUES (@Start_Time, @End_Time, @Duration)";
    }

    public static string ViewAllCommand()
    {
        {
            return "SELECT * FROM Coding_Tracker";
        }
    }
    public static string DeleteSingleRecord(string id)
    {


        return $"DELETE FROM Coding_Tracker WHERE id = {id}";
    }
}

 