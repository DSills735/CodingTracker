internal class UnitTests { 

    [TestCase("03-30-1999 12:00:00", true)]
    [TestCase("12-21-2025 12:30:01", true)]
    [TestCase("02-29-2000 12:00:00", true)]
    [TestCase("03-08-2026 02:30:00", true)]
    public void DateTimeValidation_ReturnsTrue(DateTime input, bool expectResult)
    {

        var time = Validation.DateTimeValidation(input);

        Assert.That(time, Is.EqualTo(expectResult));
    }

    [Test]
    public void CalulatesDuration_ReturnsThree()
    {

        var duration = CalculateDuration.CalculateTimeDuration(DateTime.Now, DateTime.Now.AddHours(3));

        Assert.That(duration, Is.EqualTo(TimeSpan.FromHours(3)).Within(TimeSpan.FromSeconds(1)));
    }
}
