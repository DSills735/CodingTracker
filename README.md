# Flashcards 
This app is a Console app that will allow myself to track my coding hours if I choose to do so. And view my history of my coding practices. 

**Tech used:** C#, Sqlite, VS 2026, Spectre, Dapper

I used C# along with Dapper and Spectre to design the application. I was a bit nervous to introduce both dapper and spectre at the same time, as on the surface level it seemed very daunting. Once I looked into them I realized how simple it all seemed, and had fun learning them! Using dapper over ADO.NET was a gamechanger! So simple!

## Optimizations

I did alot of refactoring throughout this project.  I originally built it to functionality using skills I already had, in an effort to reinforce the basics. Once there, I dove into the new requirements and skills which really streamined things (specifically looking at Dapper ORM). Using dapper significantly reduced the lines of code and boilerplate code. It was very eye opening to the power of libraries and packages. 


## Lessons Learned

This project was the first one I have done with C# and outside of school that required packages from the outside to do alot of the heavy lifting for me. I enjoyed using SQLLite as it has been well over a year since I have done anything SQL. I was excited to see how fast I picked it back up! 

The most important lesson I learned was SQL injection risks. I originally had it where the SQL command for DeleteSingleRecord used interpolation to put the ID directly into the command. Feedback informed me of the SQL Injection risk, which really opened my eyes. I have learned about it several times, but this was the first time it truly registered howq SQL injection actually happens. 

Another lesson I learned was UI design. Although this is very simple, as I was testing and using the app during development, I had alot of thoughts about a typical user experience with this app. It really made me think about how to simplify and streamline processes, even with something as simple as this. 

## Project Requirements

 - This is a project I did as a part of my learning process. The requirements and challenges are listed below. There was more unit tests previously, but those methods have been refactored and removed. 

 - To show the data on the console, you should use the "Spectre.Console" library.

 - You're required to have separate classes in different files (ex. UserInput.cs, Validation.cs, CodingController.cs)

 - You should tell the user the specific format you want the date and time to be logged and not allow any other format.

 - You'll need to create a configuration file that you'll contain your database path and connection strings.

 - You'll need to create a "CodingSession" class in a separate file. It will contain the properties of your coding session: Id, StartTime, EndTime, Duration

 - The user shouldn't input the duration of the session. It should be calculated based on the Start and End times, in a separate "CalculateDuration" method.

 - The user should be able to input the start and end times manually.

 - You need to use Dapper ORM for the data access instead of ADO.NET.

 - When reading from the database, you can't use an anonymous object, you have to read your table into a List of Coding Sessions.

**Challenges for this project include:**
 - Add a stopwatch feature that tracks coding as it is happening. 
 - Let users filter the database based on time period, and reorder ascending or descending. 


