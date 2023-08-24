namespace Trakk.Utils.Extensions;

public static class DateTimeExtensions
{

    public static DateTime Average(this DateTime src, params DateTime[] otherDates)
    {
        var count = otherDates.Length + 1;
        return new DateTime(src.Ticks / count + 
                        otherDates.Sum(dt => dt.Ticks / count));
    }

    public static DateTime Truncate(this DateTime src, long resolution)
    {
        return new DateTime(src.Ticks - (src.Ticks % resolution), src.Kind);
    }
    
    public static DateTime SwitchTimezone(this DateTime src,TimeZoneInfo to)
    {
        return TimeZoneInfo.ConvertTime(src, to);
    }
    
    public static TimeOnly ToTimeOnly(this DateTime dateTime) => TimeOnly.FromDateTime(dateTime);
    public static double GetTotal(this TimeSpan timeSpan, TimeSpanType type) => type switch
    {
        TimeSpanType.Milliseconds => timeSpan.TotalMilliseconds,
        TimeSpanType.Seconds => timeSpan.TotalSeconds,
        TimeSpanType.Minutes => timeSpan.TotalMinutes,
        TimeSpanType.Hours => timeSpan.TotalHours,
        TimeSpanType.Days => timeSpan.TotalDays,
        _ => timeSpan.TotalHours
    };
    
    public enum TimeSpanType
    {
        Milliseconds,
        Seconds,
        Minutes,
        Hours,
        Days,
    }
}