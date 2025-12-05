public class CodingSession
{
    internal static void StartCodingSession()
    {
        DateTime start;
        DateTime end;
        Console.Clear();
        Console.WriteLine("You are starting a new coding session, when you are ready to start press 1. If you would like to exit to the main menu, press Q.");
        //bool validReply = false;
        string response = Console.ReadLine()!;

        if (response == "1")
        {
            bool validInput = false;
            start = DateTime.Now;
            Console.WriteLine($"You have begun your coding session at {start}. Good luck. Dont forget the \";\"!");
            Console.WriteLine();
            Console.WriteLine("When you finish this session, please enter \"1\"");
            string userInput = Console.ReadLine()!;
            while (!validInput)
            {

                if (userInput == "1")
                {
                    validInput = true;
                    end = DateTime.Now;
                    Console.WriteLine($"You finished your coding session at {end}. Calculating duration now...");
                    //CalulcateDuration();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 1 if you wish to finish.");
                    userInput = Console.ReadLine()!;
                }
            }
        }
        else if (response.Trim().ToLower() == "q")
        {
            Program.MainMenu();

        }
        else
        {
            Console.WriteLine("Invalid Input, please try again.");
            StartCodingSession();
        }
    }
}

