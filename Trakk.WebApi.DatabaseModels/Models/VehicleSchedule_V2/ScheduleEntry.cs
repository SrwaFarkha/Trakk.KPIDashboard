using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Trakk.Utils.Extensions;

namespace Trakk.WebApi.DatabaseModels.Models.VehicleSchedule_V2;

public class ScheduleEntry : IEntity
{
    public ScheduleEntry()
    {
    }

    public ScheduleEntry(int startHour, int startMinute, int startSecond, int endHour, int endMinute, int endSecond,
        params DayOfWeek[] activeDays)
        : this(new TimeOnly(startHour, startMinute, startSecond), new TimeOnly(endHour, endMinute, endSecond),
            activeDays)
    {
    }

    public ScheduleEntry(TimeOnly startTime, TimeOnly stopTime, params DayOfWeek[] activeDays)
    {
        StartTime = startTime;
        StopTime = stopTime;
        ActiveDays = activeDays.ToList();
    }

    public int Id { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly StopTime { get; set; }
    public List<DayOfWeek> ActiveDays { get; set; }
    public int? ScheduleId { get; set; }

    [JsonIgnore] public virtual Schedule? Schedule { get; set; }

    public static ScheduleEntry NewActiveAllWeek(int startHour, int startMinute, int endHour, int endMinute) =>
        NewActiveAllWeek(startHour, startMinute, 00, endHour, endMinute, 59);

    public static ScheduleEntry NewActiveAllWeek(int startHour, int startMinute, int startSecond, int endHour,
        int endMinute, int endSecond)
    {
        return new ScheduleEntry(startHour, startMinute, startSecond, endHour, endMinute, endSecond,
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday);
    }

    public DateTimePair ToDateTimePair(DateTime date)
    {
        return new DateTimePair
        {
            Start = new DateTime(date.Year, date.Month, date.Day, StartTime.Hour, StartTime.Minute, StartTime.Second,
                date.Kind),
            End = new DateTime(date.Year, date.Month, date.Day, StopTime.Hour, StopTime.Minute, StopTime.Second,
                date.Kind)
        };
    }

    public IEnumerable<DateTimePair> ToDateTimes(DateTime checkTime) =>
        ActiveDays
            .Select(day => Math.Abs(checkTime.DayOfWeek - day))
            .Select(days => checkTime.AddDays(days))
            .Select(ToDateTimePair).ToList();

    public bool IsActive(DateTime checkTime)
    {
        return ActiveDays.Contains(checkTime.DayOfWeek) &&
               StartTime <= checkTime.ToTimeOnly()
               && StopTime >= checkTime.ToTimeOnly();
    }

    public TimeSpan GetTotalWorking(DateTime startTime, DateTime stopTime)
    {
        var start = TimeOnly.FromDateTime(startTime);
        var stop = startTime.DayOfWeek != stopTime.DayOfWeek 
            ? stopTime.AddTicks(-1).ToTimeOnly()
            : stopTime.ToTimeOnly();
        
        if (!ActiveDays.Contains(startTime.DayOfWeek))
            return TimeSpan.Zero;
        
        return GetTotalWorking(start, stop);
    }
    public TimeSpan GetTotalWorking(TimeOnly start, TimeOnly stop)
    {
     
        var totalWorking = TimeSpan.Zero;
        var startTime = start < StartTime ? StartTime : start;
        
        if (stop < startTime)
            return TimeSpan.Zero;
        
        var stopTime = stop > StopTime ? StopTime : stop;

        totalWorking = stopTime - startTime;

        return totalWorking;
    }


    public override string ToString()
    {
        return $"{StartTime} - {StopTime}";
    }

    public static implicit operator List<object>(ScheduleEntry v)
    {
        throw new NotImplementedException();
    }
}