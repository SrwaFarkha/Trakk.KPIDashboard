namespace Trakk.Configuration.Models;

public class JwtSettings
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Secret { get; set; }
    public TimeSpanSetting Expiration { get; set; }
}

public class TimeSpanSetting
{
    public int Value { get; set; }
    public TimeSpanType Type { get; set; }

    public TimeSpan ToTimeSpan() =>
        Type switch
        {
            TimeSpanType.Milliseconds => TimeSpan.FromMilliseconds(Value),
            TimeSpanType.Seconds => TimeSpan.FromSeconds(Value),
            TimeSpanType.Minutes => TimeSpan.FromMinutes(Value),
            TimeSpanType.Hours => TimeSpan.FromHours(Value),
            TimeSpanType.Days => TimeSpan.FromDays(Value),
            TimeSpanType.Months => DateTime.UtcNow.AddMonths(Value) - DateTime.UtcNow,
            TimeSpanType.Years => DateTime.UtcNow.AddYears(Value) - DateTime.UtcNow,
            _ => TimeSpan.FromSeconds(Value)
        };

    public enum TimeSpanType
    {
        Milliseconds,
        Seconds,
        Minutes,
        Hours,
        Days,
        Months,
        Years
    }
}