using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Trakk.WebApi.Models;


namespace Trakk.WebApi.DatabaseModels.Models.VehicleEvent_V2;

public class TripEvent : VehicleEvent
{
    public TripEvent()
    {
        Type = Enums.VehicleEventType_V2.Trip;
    }

    public TripEvent(StopEvent parentNode, EventPosition position, double distance, Enums.HardwareType hardwareType,
        bool isPrivate = false, string driver = "") : base(parentNode,
        position.TimeStamp, hardwareType)
    {
        Previous = parentNode;
        Distance = distance;
        Private = isPrivate;
        Driver = driver;
        Next = new StopEvent(this, position, hardwareType)
        {
            Private = isPrivate,
            Driver = driver,
            StopPosition = position.Position,
            StopPositionId = position.PositionId
        };
    }

    [NotMapped]
    public StopEvent PreviousStop
    {
        get => Previous as StopEvent;
        set => Previous = value;
    }

    [NotMapped]
    public StopEvent NextStop
    {
        get => Next as StopEvent;
        set => Next = value;
    }

    // TODO: Do not use bird-distance between start & stop 
    public override bool Validate()
    {
        // [2303] Gör "teleport"-resor synliga men fortsätt göm "drift"-resor
        if (EventConfiguration.MaxDistancePerPos > 0)
        {
            var distPerPos = Distance / (PositionCount + 1);
            Valid = distPerPos <= EventConfiguration.MaxDistancePerPos;
        }
        else
        {
            Valid = true;
        }

        return Valid;
    }

    private double PositionDistance()
    {
        var positions = Positions.OrderBy(x => x.TimeStamp).ToList();
        var distance = 0.0;
        for (var i = 1; i < positions.Count; i++) distance += positions[i - 1].Position.Distance(positions[i].Position);

        return distance;
    }

    public override string GetAddress()
    {
        return Previous.GetAddress();
    }

    public override string ToString()
    {
        return
            $"{GetType().Name}:  {StartTime} - {StopTime}, Duration: {StopTime - StartTime} Distance: {Distance} cost: {CongestionTaxPassages.Sum(x => x.Cost)} valid: {Validate()} positionCount: {PositionCount + 2}";
    }

    public List<Position> GetPositionsWithStartAndStop()
    {
        var positions = new List<Position>();
        if (PreviousStop?.StopPosition != null)
            positions.Add(PreviousStop.StopPosition);
        positions.AddRange(Positions.OrderBy(x => x.TimeStamp).Select(x => x.Position));
        if (NextStop?.StopPosition != null)
            positions.Add(NextStop.StopPosition);

        return positions;
    }
    public List<EventPosition> GetEventPositionsWithStartAndStop()
    {
        var positions = new List<EventPosition>();
        if (PreviousStop != null)
            positions.Add(new EventPosition
            {
              Position = PreviousStop.StopPosition,
              TimeStamp = StartTime
            });
        positions.AddRange(Positions.OrderBy(x => x.TimeStamp));
        if (NextStop != null)
            positions.Add(new EventPosition
            {
                Position = NextStop.StopPosition,
                TimeStamp = StopTime?? DateTime.Now
            });

        return positions;
    }

    public override Position GetStartPosition()
    {
        return PreviousStop.StopPosition;
    }

    public override Position GetStopPosition()
    {
        return NextStop.StopPosition;    
    }

    public override double CalculatePositionDistance()
    {
        var selected = PreviousStop.StopPosition;
        if (selected == null)
            return 0;
        var distance = 0.0d;
        foreach (var ep in Positions.OrderBy(x => x.TimeStamp))
        {
            distance += selected.Distance(ep.Position);
            selected = ep.Position;
        }
        distance += selected.Distance(NextStop.StopPosition);

        return distance;
    }
}