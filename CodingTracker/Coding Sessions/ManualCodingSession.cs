using System.Globalization;

public class ManualCodingSession
{
    internal static void ManualSession()
    {
        Console.Clear();
        Console.WriteLine("You are manually inputting a coding session. Please enter the start Date and Time (24 Hour). (MM/DD/YYYY HH:MM)");
        DateTime start;
        DateTime end;

        string startTime = Console.ReadLine()!;
        bool valid = false; 

        while (!DateTime.TryParseExact(startTime, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out start))
        {
            Console.WriteLine("Invalid format. Please enter the start Date and Time in the format (MM/DD/YYYY HH:MM)");
            startTime = Console.ReadLine()!;

            
        }
        Console.WriteLine();
        Console.WriteLine("Enter the end Date and Time (24 Hour). (MM/DD/YYYY HH:MM)");
        string endTime = Console.ReadLine()!;

        while (!DateTime.TryParseExact(endTime, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out end))
        {
            Console.WriteLine("Invalid format. Please enter the end Date and Time in the format (MM/DD/YYYY HH:MM)");
            endTime = Console.ReadLine()!;
            valid = false;
           
        }
        
         TimeSpan duration = CalculateDuration.CalculateTimeDuration(start, end);

        String timeSpentCoding = CalculateDuration.TimeFormatter(duration);

        Console.WriteLine($"You coded for a total of {timeSpentCoding}. Great work!");

        DatabaseManager.AddRecordToDatabase(start, end, timeSpentCoding);

        Program.MainMenu();
    }
}
