internal class UnitTests { 
    [Test]
    public void CalulatesDuration_ReturnsThree()
    {

        var duration = CalculateDuration.CalculateTimeDuration(DateTime.Now, DateTime.Now.AddHours(3));

        Assert.That(duration, Is.EqualTo(TimeSpan.FromHours(3)).Within(TimeSpan.FromSeconds(1)));
    }
}
