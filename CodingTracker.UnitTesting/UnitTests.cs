internal class UnitTests { 
    [Test]
    public void CalulatesDuration_ReturnsThree()
    {

        var duration = CalculateDuration.CalculateTimeDuration(DateTime.Now, DateTime.Now.AddHours(3));

        Assert.That(duration, Is.EqualTo(TimeSpan.FromHours(3)).Within(TimeSpan.FromSeconds(1)));
    }

    [TestCase(0, 5, 9, "00:05:09")]
    [TestCase(0, 0, 0, "00:00:00")]
    [TestCase(0, 5, 9, "00:05:09")]
    [TestCase(1, 10, 20, "01:10:20")]
    [TestCase(12, 34, 56, "12:34:56")]
    [TestCase(23, 59, 59, "23:59:59")]
    [TestCase(24, 0, 0, "00:00:00")]
    [TestCase(26, 30, 0, "02:30:00")]
    [TestCase(0, 0, 65, "00:01:05")]
    [TestCase(0, 120, 0, "02:00:00")]
    [TestCase(5, -30, 0, "04:30:00")]
    public void TimeFormatter_ReturnsFormattedString(int hours, int minutes, int seconds, string expected)
    {
        TimeSpan duration = new TimeSpan(hours, minutes, seconds);
        string result = CalculateDuration.TimeFormatter(duration);
        Assert.That(result, Is.EqualTo(expected));
    }

}
