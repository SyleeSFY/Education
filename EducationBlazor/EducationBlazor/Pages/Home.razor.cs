public class TimeToNewYear
{
    private DateTime _newYear = new DateTime(2026, 01, 01, 00, 00, 00);

    public TimeSpan GetTimeToNewYear()
        => _newYear - DateTime.Now;
    
    public string GetFormattedTime()
    {
        var timeLeft = GetTimeToNewYear();
        return $"{timeLeft.Days} дней, {timeLeft.Hours} часов, {timeLeft.Minutes} минут, {timeLeft.Seconds} секунд";
    }
}