using System;

namespace Trakk.WebApi.DatabaseModels.Models.VehicleEvent_V2;

public class EventPosition
{    public EventPosition()
    {
        
    }
    public EventPosition(Position position, DateTime timeStamp)
    {
        Position = position;
        TimeStamp = timeStamp;
    }
    public EventPosition(decimal longitude, decimal latitude, DateTime timeStamp) : this(new Position(0, longitude, latitude), timeStamp)
    {
    }
    public EventPosition(double longitude, double latitude, DateTime timeStamp) : this((decimal)longitude,(decimal)latitude, timeStamp)
    {
    }
    public int Id { get; set; }
    public int PositionId { get; set; }
    public Position Position { get; set; }
    public DateTime TimeStamp { get; set; }
    public int VehicleEventId { get; set; }
    public int? IsaEventId { get; set; }
    
}