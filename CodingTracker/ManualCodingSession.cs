using System.Globalization;

public class ManualCodingSession
{
    internal static void ManualSession()
    {
        Console.Clear();
        Console.WriteLine("You are manually inputting a coding session. Please enter the start Date and Time (24 Hour). (MM/DD/YY HH:MM)");
        DateTime start;
        DateTime end;

        string startTime = Console.ReadLine()!;

        while (!DateTime.TryParseExact(startTime, "MM/dd/yy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out start))
        {
            Console.WriteLine("Invalid format. Please enter the start Date and Time in the format (MM/DD/YY HH:MM)");
            startTime = Console.ReadLine()!;
        }

        Console.WriteLine("Enter the end Date and Time (24 Hour). (MM/DD/YY HH:MM)");
        string endTime = Console.ReadLine()!;

        while (!DateTime.TryParseExact(endTime, "MM/dd/yy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out end))
        {
            Console.WriteLine("Invalid format. Please enter the end Date and Time in the format (MM/DD/YY HH:MM)");
            endTime = Console.ReadLine()!;
        }
        
         TimeSpan duration = CalculateDuration.CalculateTimeDuration(start, end);

        String timeSpentCoding = $"{duration.Hours:00}:{duration.Minutes:00}:{duration.Seconds:00}";
        Console.WriteLine($"You coded for a total of {timeSpentCoding}. Great work!");

        DatabaseManager.AddRecordToDatabase(start, end, timeSpentCoding);
    }
}
