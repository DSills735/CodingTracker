using System.Data;
using System.Runtime.CompilerServices;
using Microsoft.Data.Sqlite;
using Dapper;

namespace Main
{


    public class Main
    {
        static string connectionStr = "Data Source = codingTracker.db";
        static void tableCreate(string[] args)
        {
            using(var connection = new SqliteConnection(connectionStr))
            {
                connection.Open();

                var tableCommand = connection.CreateCommand();
                tableCommand.CommandText = @"CREATE TABLE IF NOT EXISTS Coding_Tracker(
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Start_Time TIME,
                                            End_Time TIME,
                                            Duration TIME)";

                tableCommand.ExecuteNonQuery();
                connection.Close();
            }

        }
    internal void MainMenu(){
                Console.WriteLine("Welcome to David's Coding tracker! Below will be a few options. Select the option that you need by typing the corresponding number.");
                Console.WriteLine("1. Start a coding session");
                Console.WriteLine("2. Input a coding session manually");
                Console.WriteLine("3. View History");
                //Need more but not 100% sure what yet.
        }
    }

}