using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Trakk.WebApi.DatabaseModels.Models.CongestionTaxV2;
using Trakk.WebApi.Models;


namespace Trakk.WebApi.DatabaseModels.Models.VehicleEvent_V2;

public abstract class VehicleEvent
{
    public VehicleEvent()
    {
    }

    public VehicleEvent(VehicleEvent parentNode, DateTime startTime, Enums.HardwareType hardwareType)
    {
        //EventConfiguration = eventConfiguration ?? EventConfigurations.Jm();
        HardwareType = hardwareType;

        StartTime = GetType() == typeof(StopEvent)
            ? startTime
            : startTime - EventConfiguration.BootTime;

        if (parentNode == null) return;

        Previous = parentNode;
        VehicleId = parentNode.VehicleId;
    }

    public int Id { get; set; }
    public Enums.VehicleEventType_V2 Type { get; set; }
    [NotMapped] public TimeSpan? Duration => StopTime - StartTime;
    public EventConfiguration EventConfiguration => EventUtils.ConfigManager[HardwareType];
    public Enums.HardwareType HardwareType { get; set; }
    public bool Valid { get; set; } = true;
    public bool Private { get; set; } = false;
    public int VehicleId { get; set; }
    public virtual Vehicle? Vehicle { get; set; }
    public DateTime? StopTime => Next?.StartTime;
    public DateTime StartTime { get; set; }
    public List<EventPosition> Positions { get; set; } = new();
    public int PositionCount { get; set; }
    public int? PreviousId { get; set; }
    public VehicleEvent Next { get; set; }
    public VehicleEvent Previous { get; set; }
    public string Comment { get; set; }
    public string Driver { get; set; }
    public int? AccountId { get; set; }
    public Account Account { get; set; }
    public bool DriverLocked { get; set; }
    public double Distance { get; set; }
    public List<Passage> CongestionTaxPassages { get; set; } = new List<Passage>();

    public bool UserDeleted { get; set; }

    public int? OdometerMeter { get; set; }
    public int? RouteId { get; set; }
    public virtual Route? Route { get; set; }
    public ICollection<IsaEvent> IsaEvents { get; set; }
    public bool SafetyZone { get; set; }


    public abstract bool Validate();

    public VehicleEvent Last()
    {
        var cur = this;
        while (cur.Next != null) cur = cur.Next;

        return cur;
    }

    public TEvent Last<TEvent>() where TEvent : VehicleEvent
    {
        var cur = this;
        while (cur.Next != null) cur = cur.Next;

        return (cur.GetType() == typeof(TEvent) ? cur : cur.Previous) as TEvent;
    }

    public List<VehicleEvent> ToList()
    {
        var selected = Last();
        var collection = new List<VehicleEvent>();
        while (selected != null)
        {
            collection.Add(selected);
            selected = selected.Previous;
        }
        return collection;
    }
    public virtual double CalculatePositionDistance()
    {
        var positions = Positions.OrderBy(x => x.TimeStamp).ToArray();
        var selected = positions.First();
        var distance = 0.0d;
        foreach (var ep in positions.Skip(1))
        {
            distance += selected.Position.Distance(ep.Position);
            selected = ep;
        }
        return distance;
    }

    public string[] ReadCommentAsGeofences()
    {
        return string.IsNullOrEmpty(Comment) 
            ? Array.Empty<string>() 
            : Comment.Split(", ", StringSplitOptions.RemoveEmptyEntries);
    }

    public EventPosition? GetNewestPosition()
    {
        return Positions.MaxBy(x => x.TimeStamp);
    }
    public virtual Position GetStartPosition()
    {
        return Positions.FirstOrDefault()?.Position;
    }
    public virtual Position GetStopPosition()
    {
        return Positions.LastOrDefault()?.Position;
    }
    

    public double GetDistanceKm() => Distance / 1000;

    public abstract string GetAddress();

    public override string ToString()
    {
        return
            $"{GetType().Name}:  {StartTime} - {StopTime}, Duration: {StopTime - StartTime}, Positions: (var){PositionCount}(list){Positions.Count}, Valid: {Valid} ";
    }
}