
using Microsoft.Data.Sqlite;
using Dapper;

namespace CodingTracker.Testing;


public class IntegrationTests
{
    string connString = "Data Source=:memory:";

    //private readonly SqliteConnection _connection;
    [Test]
    public void AddRecordToDatabase_AddsRecordToDb()
    {
        using var connection = new SqliteConnection(connString);
        connection.Open();

        //arrange
        DateTime start = DateTime.Parse("2024-01-01 10:00:00");
        DateTime end = DateTime.Parse("2024-01-01 11:00:00");
        string duration = "1:00:00";
        var tableCreate = SqlHelper.TableCreate();
        connection.Execute(tableCreate);
        //act
        DatabaseManager.AddRecordToDatabase(start, end, duration, connection);
        //assert
        var count = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Coding_Tracker");
        Assert.That(count, Is.GreaterThan(0));
        connection.Close();
    }
}
