using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Trakk.Configuration;

using Trakk.WebApi.Models;


namespace Trakk.WebApi.DatabaseModels.Models.VehicleEvent_V2;


public class EventUtils
{
    public static EventConfigurationManager ConfigManager { get; } = EventConfigurationManager.Load();
}

public class EventConfigurationManager
{
    public List<EventConfiguration> Configurations { get; private init; }
    //public static readonly EventConfiguration Jm = new(80, 20,  TimeSpan.FromSeconds(40), TimeSpan.FromSeconds(240), 2, TimeSpan.FromMinutes(45), 3, 83, 10000, Enums.HardwareType.JM01, Enums.HardwareType.GT08);

    public EventConfiguration DefaultConfig =>
        Configurations?.FirstOrDefault(x => x.SupportedHardware.Contains(Enums.HardwareType.Undefined))??
        new(150, 50,  TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(300), 2, TimeSpan.FromMinutes(45), 3, 83, 10000, Enums.HardwareType.Undefined);
    //public static readonly EventConfiguration DebugPreciseConfig = new(1, 1,  TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(300), 2, TimeSpan.FromMinutes(45), 3, 83, 10000);

    public static EventConfigurationManager Load()
    {
        return new EventConfigurationManager
        {
            Configurations = ConfigManager.Instance.Get<List<EventConfiguration>>("VehicleEventConfigurations")
        };

    }

    public EventConfiguration this[Enums.HardwareType hardwareType] 
        => Configurations?.FirstOrDefault(x => x.SupportedHardware.Contains(hardwareType)) 
           ?? DefaultConfig;
}
public class EventConfiguration
{
    public EventConfiguration()
    {
    }

    public EventConfiguration(double distanceLong, double distanceShort, TimeSpan bootTime, TimeSpan stopTime, int minTripPositions, TimeSpan maxTunnelTime, int minSpeedTunnel, int maxSpeed,int maxDistancePerPos, params Enums.HardwareType[] supportedHardware)
    {
        DistanceLong = distanceLong;
        DistanceShort = distanceShort;
        BootTime = bootTime;
        StopTime = stopTime;
        MinTripPositions = minTripPositions;
        MaxTunnelTime = maxTunnelTime;
        MinSpeedTunnel = minSpeedTunnel;
        MaxDistancePerPos = maxDistancePerPos;
        MaxSpeed = maxSpeed;
        SupportedHardware = supportedHardware;
    }
    public Enums.HardwareType[] SupportedHardware { get; set; }
    public double DistanceLong { get; set; } = 150;                              // Long distance to start a new trip
    public double DistanceShort { get; set; } = 50;                              // Short distance to continue a trip
    public TimeSpan BootTime { get; set; } = TimeSpan.FromSeconds(60);           // Startup time for hardware (seconds)
    public TimeSpan StopTime { get; set; } = TimeSpan.FromSeconds(300);          // Stop time , default 180second 
    public double Gain(int count) => (1.0 / (count * (count / 2 )));
    public int MinTripPositions { get; set; } = 2;
    public TimeSpan MaxTunnelTime { get; set; } = TimeSpan.FromMinutes(45);
    public int MinSpeedTunnel { get; set; } = 3;                                 // m/s
    public double MaxSpeed { get; set; } = 83;                                 // m/s
    public int MaxDistancePerPos { get; set; } = 10000;                                 // m/s
    public TimeSpan StopMargin => StopTime + BootTime;
}