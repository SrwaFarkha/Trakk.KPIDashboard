using System;
using System.Collections.Generic;
using Trakk.WebApi.DatabaseModels.Models.VehicleEvent_V2;

using static Trakk.WebApi.Models.Enums;

namespace Trakk.WebApi.DatabaseModels.Models
{
    public partial class Vehicle : IEntity
    {
        public int VehicleId { get; set; } // VehicleId (Primary key)
        public int CustomerId { get; set; } // CustomerId
        public DateTime CreatedOn { get; set; } // CreatedOn
        public string? Name { get; set; } // Name (length: 50)
        public bool IsActive { get; set; } // IsActive
        public bool IsDeleted { get; set; } // IsDeleted
        public bool HasCongestionTax { get; set; } // HasCongestionTax
        public bool HasExternalRouteSource { get; set; } // HasExternalRouteSource
        public bool HasVehicleEventProcessor { get; set; } // HasVehicleEventProcessor
        public bool HasIsaEventProcessor { get; set; } // HasIsaEventProcessor
        public string? VehicleRegistrationNumber { get; set; } // VehicleRegistrationNumber (length: 50)
        public string? Vin { get; set; } // VIN (length: 50)
        public string? Driver { get; set; } // Driver (length: 256)
        public int? AccountId { get; set; }
        public Account Account { get; set; }
        public DriverAssignment DriverAssignment { get; set; }
        public DateTime? DriverAssignmentValidUntil { get; set; }
        public int? LatestTrakkerEventId { get; set; } // LatestTrakkerEventId
        public int? OdometerMeter { get; set; } // OdometerMeter
        public int? Co2 { get; set; } // CO2
        public string TimeZoneId { get; set; } // TimeZoneId (length: 250)
        public int? LatestStopEventId { get; set; }
        public virtual StopEvent? LatestStopEvent { get; set; }
        public FuelType FuelType { get; set; }
        public double FuelConsumption{ get; set; }

        
        // Reverse navigation

        /// <summary>
        /// Child Categories (Many-to-Many) mapped by table [CategoryVehicleMap]
        /// </summary>
        public virtual ICollection<Category> Categories { get; set; } // Many to many mapping

        /// <summary>
        /// Child Trakkers (Many-to-Many) mapped by table [TrakkerVehicleMap]
        /// </summary>
        public virtual ICollection<Trakker> Trakkers { get; set; } // Many to many mapping

        /// <summary>
        /// Child VehicleEvents where [VehicleEvent].[VehicleId] point to this entity (FK_VehicleEvent_Vehicle)
        /// </summary>
       // public virtual ICollection<VehicleEvent> VehicleEvents { get; set; } // VehicleEvent.FK_VehicleEvent_Vehicle
        

        public virtual ICollection<VehicleEvent_V2.VehicleEvent> VehicleEvents { get; set; } // VehicleEvent.FK_VehicleEvent_Vehicle


        /// <summary>
        /// Child VehicleSchedules where [VehicleSchedule].[VehicleId] point to this entity (FK_VehicleScheduleVehicle)
        /// </summary>
       // public virtual ICollection<VehicleSchedule> VehicleSchedules { get; set; } // VehicleSchedule.FK_VehicleScheduleVehicle
        

        // Foreign keys

        /// <summary>
        /// Parent Customer pointed by [Vehicle].([CustomerId]) (FK_Vehicle_Customer)
        /// </summary>
        public virtual Customer Customer { get; set; } // FK_Vehicle_Customer

        /// <summary>
        /// Parent TrakkerEvent pointed by [Vehicle].([LatestTrakkerEventId]) (FK_Vehicle_TrakkerEvent)
        /// </summary>
        public virtual TrakkerEvent LatestTrakkerEvent { get; set; } // FK_Vehicle_TrakkerEvent

        public Vehicle()
        {
            CreatedOn = DateTime.UtcNow;
            IsActive = true;
            IsDeleted = false;
            HasCongestionTax = false;
            HasExternalRouteSource = false;
            HasVehicleEventProcessor = false;
            HasIsaEventProcessor = false;
            Driver = "";
            DriverAssignment = DriverAssignment.NotAssigned;
            TimeZoneId = "UTC";
           // VehicleEvents = new List<VehicleEvent>();
            VehicleEvents = new List<VehicleEvent_V2.VehicleEvent>();
           // VehicleSchedules = new List<VehicleSchedule>();
            Categories = new List<Category>();
            Trakkers = new List<Trakker>();
        }
    }
}