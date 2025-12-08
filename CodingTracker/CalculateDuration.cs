//this is going to use the start and end time from coding session to calculate the duration of the session.
public class CalculateDuration
{
    internal static TimeSpan CalculateTimeDuration(DateTime start, DateTime end)
    {

        TimeSpan duration = end - start;


        return duration;
    }
}