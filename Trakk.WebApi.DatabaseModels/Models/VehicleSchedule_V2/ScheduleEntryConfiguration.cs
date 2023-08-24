using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trakk.WebApi.DatabaseModels.Models.VehicleEvent_V2;

namespace Trakk.WebApi.DatabaseModels.Models.VehicleSchedule_V2;



public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity.Property(e => e.Id).HasColumnType("int");
        entity.Property(e => e.OverrideTime).HasMaxLength(6);
        entity.Property(c => c.TimeZoneInfo).HasConversion(
            x => x.Id,
            x => TimeZoneInfo.FindSystemTimeZoneById(x));
        entity.HasMany(x => x.Entries).WithOne(x => x.Schedule);
    }
}

public class ScheduleEntryConfiguration : IEntityTypeConfiguration<ScheduleEntry>
{
    public void Configure(EntityTypeBuilder<ScheduleEntry> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.HasIndex(e => e.ScheduleId, "IX_ScheduleEntries_ScheduleId");

        builder.Property(e => e.Id).HasColumnType("int");
        builder.Property(e => e.ScheduleId).HasColumnType("int");
        
        builder.Property(x => x.StartTime).HasConversion<TimeOnlyConverter, TimeOnlyComparer>();
        builder.Property(x => x.StopTime).HasConversion<TimeOnlyConverter, TimeOnlyComparer>();
        builder.Property(x => x.ActiveDays).HasConversion<WeekDayConverter, WeekDayComparer>();
        builder.HasOne(d => d.Schedule)
            .WithMany(p => p.Entries)
            .HasForeignKey(d => d.ScheduleId);
    }
}

public class WeekDayConverter : ValueConverter<List<DayOfWeek>, string>
{
    public WeekDayConverter() : base(
        l => string.Join(",", l),
        l => l.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(Enum.Parse<DayOfWeek>).ToList())
    {
    }

}

public class WeekDayComparer : ValueComparer<List<DayOfWeek>>
{
    public WeekDayComparer() : base(
        (t1, t2) => t1 == t2,
        t => t.GetHashCode())
    {
    }
}

public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
{
    public TimeOnlyConverter() : base(
        timeOnly => timeOnly.ToTimeSpan(),
        timeSpan => TimeOnly.FromTimeSpan(timeSpan))
    {
    }
}

public class TimeOnlyComparer : ValueComparer<TimeOnly>
{
    public TimeOnlyComparer() : base(
        (t1, t2) => t1.Ticks == t2.Ticks,
        t => t.GetHashCode())
    {
    }
}