
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


    [Test]
    public void TableCreate_EnsuresTableIsCreated()
    {
        using var connection = new SqliteConnection(connString);
        connection.Open();
        //act
        var tableCreate = SqlHelper.TableCreate();
        connection.Execute(tableCreate);
        //assert
        var result = connection.QueryFirstOrDefault<string>("SELECT name FROM sqlite_master WHERE type='table' AND name='Coding_Tracker';");
        Assert.That(result, Is.EqualTo("Coding_Tracker"));
        connection.Close();
    }

    [Test]
    public void ViewAllCommand_ReturnsAllRecords()
    {
        using var connection = new SqliteConnection(connString);
        connection.Open();
        //arrange
        var tableCreate = SqlHelper.TableCreate();
        connection.Execute(tableCreate);
        DateTime start = DateTime.Parse("2024-01-01 10:00:00");
        DateTime end = DateTime.Parse("2024-01-01 11:00:00");
        string duration = "1:00:00";
        DatabaseManager.AddRecordToDatabase(start, end, duration, connection);
        //act
        var records = connection.Query<CodingSession>(SqlHelper.ViewAllCommand()).ToList();
        //assert
        Assert.That(records.Count, Is.EqualTo(1));
        connection.Close();

    }
    [Test]
    public void DeleteSingleRecord_RemovesRecordFromDatabase()
    {
        using var connection = new SqliteConnection(connString);
        connection.Open();

        var tableCreate = SqlHelper.TableCreate();
        connection.Execute(tableCreate);

        DateTime start = DateTime.Parse("2024-01-01 10:00:00");
        DateTime end = DateTime.Parse("2024-01-01 11:00:00");
        string duration = "1:00:00";
        DatabaseManager.AddRecordToDatabase(start, end, duration, connection);

        var record = connection.QueryFirstOrDefault<CodingSession>("SELECT * FROM Coding_Tracker LIMIT 1");
        connection.Execute(SqlHelper.DeleteSingleRecord(), new { Id = record.Id });
        record = connection.QueryFirstOrDefault<CodingSession>("SELECT * FROM Coding_Tracker LIMIT 1");

        Assert.That(record, Is.Null);
    }
}
