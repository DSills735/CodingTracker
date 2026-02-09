//this is going to use the start and end time from coding session to calculate the duration of the session.
public class CalculateDuration
{
    internal static TimeSpan CalculateTimeDuration(DateTime start, DateTime end)
    {
        TimeSpan duration = end - start;
        return duration;
    }
    internal static string TimeFormatter(TimeSpan duration) {
        string timeSpentCoding = $"{duration.Hours:00}:{duration.Minutes:00}:{duration.Seconds:00}";
        return timeSpentCoding;
    }


}