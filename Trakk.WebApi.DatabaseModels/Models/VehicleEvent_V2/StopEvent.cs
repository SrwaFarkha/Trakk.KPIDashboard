using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Trakk.WebApi.Models;


namespace Trakk.WebApi.DatabaseModels.Models.VehicleEvent_V2;

public class StopEvent : VehicleEvent
{
    public StopEvent()
    {
        Type = Enums.VehicleEventType_V2.Stop;
    }

    public StopEvent(TripEvent parentNode, EventPosition position,  Enums.HardwareType hardwareType) : base(parentNode, position.TimeStamp, hardwareType)
    {
        Positions.Add(position);
        StopPosition = position.Position;
    }

    public StopEvent(TripEvent parentNode, DateTime startTime,  Enums.HardwareType hardwareType): base(parentNode, startTime, hardwareType)
    {
    }

    [NotMapped]public TripEvent PreviousTrip
    {
        get => base.Previous as TripEvent;
        set => base.Previous = value;
    }

    [NotMapped]public  TripEvent NextTrip
    {
        get => base.Next as TripEvent;
        set => base.Next = value;
    }

    public int? StopPositionId { get; set; }
    public virtual Position? StopPosition { get; set; }

    public decimal Gain => 1.0M / Math.Max(PositionCount, 1);
    public override bool Validate()
    {
        return Valid = IsValidStop();
    }

    public override Position GetStartPosition()
    {
        return StopPosition;
    }

    public override Position GetStopPosition()
    {
        return StopPosition;
    }

    public bool IsValidStop() => PreviousId.HasValue && (StopTime == null
                                                         || StopTime - StartTime >= EventConfiguration.StopTime);

    public override string GetAddress()
    {
        return this.StopPosition?.GeocodedPosition?.Label;
    }
}