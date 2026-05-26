internal class UnitTests { 
    [TestCase("2026-05-26 10:00:00", "2026-05-26 13:00:00", 3, 0)]
    [TestCase("2026-05-26 10:00:00", "2026-05-26 10:45:00", 0, 45)]
    [TestCase("2026-05-26 22:00:00", "2026-05-27 02:00:00", 4, 0)]
    [TestCase("2026-05-26 10:00:00", "2026-05-26 10:00:00", 0, 0)]
    [TestCase("2026-05-26 15:00:00", "2026-05-26 13:00:00", -2, 0)]
    public void CalculateTimeDuration_ReturnsExpectedTimeSpan(
        string startString,
        string endString,
        int expectedHours,
        int expectedMinutes)
    {
        var startTime = DateTime.Parse(startString);
        var endTime = DateTime.Parse(endString);
        var expectedDuration = TimeSpan.FromHours(expectedHours) + TimeSpan.FromMinutes(expectedMinutes);

        var actualDuration = CalculateDuration.CalculateTimeDuration(startTime, endTime);

        Assert.That(actualDuration, Is.EqualTo(expectedDuration));
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
