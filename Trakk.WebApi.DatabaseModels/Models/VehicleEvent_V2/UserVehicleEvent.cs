using System;
using System.Collections.Generic;
using Trakk.WebApi.DatabaseModels.Models.CongestionTaxV2;


namespace Trakk.WebApi.DatabaseModels.Models.VehicleEvent_V2;

public abstract class UserVehicleEvent : VehicleEvent
{
    public string FromAddress { get; set; }
    public string ToAddress { get; set; }
    public DateTime ToDateTime { get; set; }
    public override bool Validate()
    {
        throw new NotImplementedException();
    }

    public override string GetAddress()
    {
        throw new NotImplementedException();
    }

    public UserVehicleEvent() {}
}

public class UserStopEvent : UserVehicleEvent
{
    public UserStopEvent() {}
}


public class UserTripEvent : UserVehicleEvent
{
    public UserTripEvent() {}
}