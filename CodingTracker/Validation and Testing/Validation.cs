public class Validation 
{ 
    internal static bool DateTimeValidation(DateTime timeInput) 
    {
        int day = timeInput.Day;
        int month = timeInput.Month;
        int year = timeInput.Year;
        int hour = timeInput.Hour;
        int minute = timeInput.Minute;
        //int second = timeInput.Second; <- Removed cuz it overcomplicates things IMO. Might re-add later. 

        if (day < 0 || day >= 32)
        {
            Console.WriteLine("Invalid. The day input is either below 0, or above 31. ");
            return false;
        }
        if (month == 2)
        {
            if (day > 29)
            {
                Console.WriteLine("Invalid. Febuary only has a max of 29 days.");
                return false;
            }
        }     
        else if (month == 4 || month == 6 || month == 9 || month == 11)
        {
            if (day > 30)
            {
                Console.WriteLine("Invalid. The month you have used only has 30 days.");
                return false;
            }
        }
        if(year < 0)
        {
            Console.WriteLine("Invalid. The year input cannot be negative");
            return false;
        }

        if (hour < 0 || hour >= 24)
        {
            Console.WriteLine("Invalid. The hour input is either below 0, or above 23.");
            return false;
        }

        if(minute < 0 || minute >= 60)
        {
            Console.WriteLine("Invalid. The minute input is either below 0, or above 59.");
            return false;
        }

        return true;
    }

}
