using System;

namespace Trakk.WebApi.DatabaseModels.Models.VehicleSchedule_V2;

public struct DateTimePair
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    public override string ToString()
    {
        return $"{Start} - {End}";
    }
}