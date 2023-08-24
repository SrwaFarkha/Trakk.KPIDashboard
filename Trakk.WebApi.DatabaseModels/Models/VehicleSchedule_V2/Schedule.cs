using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Trakk.Utils.Extensions;
using Trakk.Utils.Extensions.StringExtensions;
using Trakk.Utils.Helpers;


namespace Trakk.WebApi.DatabaseModels.Models.VehicleSchedule_V2;

/// <summary>
/// Override reverses result of Entries.Any(x => x.IsActive(checkTime))
/// OverrideTime is the dateTime when the user flipped the switch.
/// Using this date we convert all the Entries to real DateTimes and take the nearest one to the OverrideTime.
/// Using the entry we now have a date when the overrideTime is not valid any more.
/// If no entries exists but OverrideTime does, All dates after OverrideTime is overriden. 
///
///     \ active \  \-----active----     active \
/// Tl;Dr: Entry--OverrideTime---Entry-----Entry
/// </summary>

public class Schedule : IEntity
{
    [Key]
    public int Id { get; set; }
    public DateTime? OverrideTime { get; set; }
    public List<ScheduleEntry> Entries { get; set; } = new List<ScheduleEntry>();
    public TimeZoneInfo TimeZoneInfo { get; set; } = TimeZoneInfo.Local;
    
    /// <summary>
    ///  checks for any overrides and reverses Entry.IsActive if one is found.
    /// </summary>
    /// <param name="checkTime"></param>
    /// <returns></returns>
    public bool IsWorkingStatus(DateTime checkTime)
    {
        var converted = checkTime.ToLocalTime().SwitchTimezone(TimeZoneInfo);
        return Overrides(converted)
            ? !Entries.Any(x => x.IsActive(converted))
            : Entries.Any(x => x.IsActive(converted));
    }

    public (TimeSpan privateTime, TimeSpan workingTime) GetTotalPrivateAndWorkTime(DateTime startTime, DateTime stopTime)
    {
        if (!Entries.Any())
            return (TimeSpan.Zero, (stopTime - startTime));
        if (startTime.Kind != DateTimeKind.Local) startTime = startTime.ToLocalTime().SwitchTimezone(TimeZoneInfo);
        if (stopTime.Kind != DateTimeKind.Local) stopTime = stopTime.ToLocalTime().SwitchTimezone(TimeZoneInfo);

        var totalWorking = TimeSpan.Zero;
        var daysToCheck = new List<DateTime> { startTime };
        if (stopTime.Date.Subtract(startTime.Date).Days > 0) //add dates in between.
            daysToCheck.AddRange(Enumerable.Range(1, stopTime.Date.Subtract(startTime.Date).Days )
                .Select(offset => startTime.Date.AddDays(offset)));
        daysToCheck.Add(stopTime);
        
        // räkna ut total working i entries sen minus (start - stop) för private
        foreach (var entry in Entries )
            for (var i = 0; i < daysToCheck.Count -1 ; i++)
                totalWorking += entry.GetTotalWorking(daysToCheck[i], daysToCheck[i+1]);
        
        var totalPrivate = (stopTime - startTime) - totalWorking;    


        return (totalPrivate, totalWorking);
    }

    /// <summary>
    /// Checks if "checkTime" is within overrideTime and next schedule entry (from override time)
    /// </summary>
    /// <param name="checkTime"></param>
    /// <returns></returns>
    public bool Overrides(DateTime checkTime, bool switchInputTimeZone = false)
    {
        if (switchInputTimeZone)
            checkTime = checkTime.ToLocalTime().SwitchTimezone(TimeZoneInfo);

        if (!OverrideTime.HasValue || OverrideTime.Value == default) return false;
        
        var overrideTime =  OverrideTime.Value.SwitchTimezone(TimeZoneInfo);

        if (overrideTime.Date != checkTime.Date) return false;

        if (!Entries.Any()) return overrideTime <= checkTime;
        
        var nextActive = GetNextActive(overrideTime);
        if (nextActive.HasValue)
        {
            if (nextActive.Value.Start >= overrideTime)
                return nextActive?.Start >= checkTime;
            if (nextActive.Value.End >= overrideTime)
                return nextActive?.End >= checkTime;
        }

        return false;
    }

    
    /// <summary>
    /// Checks if provided dateTime is within overrideTime and next schedule entry (from override time)
    /// </summary>
    /// <param name="dateTime"></param>
    public void Override(DateTime dateTime) => OverrideTime = Overrides(dateTime.SwitchTimezone(TimeZoneInfo)) ? null : dateTime;
 


    /// <summary>
    /// Converts schedule entries to DateTimePairs (start & end) and gets the first entry containing checkTime 
    /// </summary>
    /// <param name="checkTime"></param>
    /// <returns>first entry containing checkTime </returns>
    public DateTimePair? GetNextActive(DateTime checkTime) =>  
        Entries.Any()
            ? Entries.SelectMany(x => x.ToDateTimes(checkTime))
                .OrderBy(x => x.Start)
                .FirstOrDefault(x => x.End >= checkTime)
            : null;
}