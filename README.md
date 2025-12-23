This is a coding tracker, created as a part of the C Sharp Academy roadmap. In this project, I am building a simple console app that will track my coding sessions, and log them in a database using Sqlite. Listed below you will find the basic requirements.  
that I have been given. Below you will find challenges that were added to the end of the project. I will add all the challenges that were suggested, and indicate my completion next to them.


Thought Process and General Notes:
My initial gut reaction to this was to use the stopwatch feature as the main tracker, and have manual input as a secondary. (I actually didnt even see the challenge for stopwatch until after I had implemented it.)
In my previous experience with habit trackers, I would lose track of time when manually inputting, and have a harder time being accurate.

Initial Steps/Thoughts:
I built the general outline of the menu, SQLite implementation and the stopwatch feature to minimal functionality. I then looked more into 
spectre and dapper, as I have no prior experience with these. I decided to build out what I knew of the implementation,
and then refactor to include dapper and spectre at a later date. Between this project, and the habit tracker I spent quite a bit of time 
building a billards scorekeeping app which is a quite similar implementation to this, minus date/time tracking. It helped with the startup proces.

Middle Steps: 
I have finished the base implementation and have it functional at the minimal functionality I would like. Now I will begin learnig dapper and spectre.
Once there I will refactor my code to satisfy those requirements. I would like to reformat the view records, and also include more data in the printout as well (I think a project assignment to a session would be cool).



Requirements:

To show the data on the console, you should use the "Spectre.Console" library.

You're required to have separate classes in different files (ex. UserInput.cs, Validation.cs, CodingController.cs)

You should tell the user the specific format you want the date and time to be logged and not allow any other format.

You'll need to create a configuration file that you'll contain your database path and connection strings.

You'll need to create a "CodingSession" class in a separate file. It will contain the properties of your coding session: Id, StartTime, EndTime, Duration

The user shouldn't input the duration of the session. It should be calculated based on the Start and End times, in a separate "CalculateDuration" method.

The user should be able to input the start and end times manually.

You need to use Dapper ORM for the data access instead of ADO.NET. (This requirement was included in Feb/2024)

When reading from the database, you can't use an anonymous object, you have to read your table into a List of Coding Sessions.

Follow the DRY Principle, and avoid code repetition.

Challenges for this project include:
Add a stopwatch feature that tracks coding as it is happening. (Done)
Let users filter the database based on time period, and reorder ascending or descending. (Not completed).
Create reports where users can see their total and average coding sessions per period. (Not completed.)
Create the ability to have goals and show how far a user is from attaining their goal. (Not completed.)
