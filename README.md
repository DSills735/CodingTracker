This is a project I did as a part of my learning process. The requirements and challenges are listed below. There was more unit tests previously, but those methods have been refactored and removed. 

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

