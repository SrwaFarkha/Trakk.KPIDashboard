using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Trakk.WebApi.DatabaseModels.Models.VehicleSchedule_V2;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public partial class Trakker : IEntity
    {
        public int TrakkerId { get; set; } // TrakkerId (Primary key)
        public int CustomerId { get; set; } // CustomerId
        public int? ScheduleId { get; set; }
        public DateTime CreatedOn { get; set; } // CreatedOn
        public string? Name { get; set; } // Name (length: 50)
        public int IconId { get; set; }// IconId
        public bool? IsActive { get; set; } // IsActive
        public bool IsDeleted { get; set; } // IsDeleted
        public int? HardwareId { get; set; } // HardwareId
        public int? LatestEventId { get; set; } // LatestEventId
        public int? LatestPositionEventId { get; set; } // LatestPositionEventId
        public string? EquipmentNumber { get; set; }
        public byte? BatteryStatus { get; set; }
        public Schedule Schedule { get; set; } = new Schedule();
        public DateTime? LastContact { get; set; }
        public string? Comment { get; set; }
        public string? CostCenter { get; set; }
        public string? Region { get; set; }
        public string? BusinessArea { get; set; }

        // Reverse navigation

        /// <summary>
        /// Child AccountTrakkerMaps where [AccountTrakkerMap].[TrakkerId] point to this entity (FK_AccountTrakkerMap_Trakker)
        /// </summary>
        public virtual ICollection<AccountTrakkerMap> AccountTrakkerMaps { get; set; } // AccountTrakkerMap.FK_AccountTrakkerMap_Trakker

        /// <summary>
        /// Child Assets where [Asset].[TrakkerId] point to this entity (FK_Asset_Trakker)
        /// </summary>
        public virtual ICollection<Asset> Assets { get; set; } // Asset.FK_Asset_Trakker

        /// <summary>
        /// Child Categories (Many-to-Many) mapped by table [CategoryTrakkerMap]
        /// </summary>
        public virtual ICollection<Category> Categories { get; set; } // Many to many mapping

        /// <summary>
        /// Child Contacts (Many-to-Many) mapped by table [TrakkerContactMap]
        /// </summary>
        public virtual ICollection<Contact> Contacts { get; set; } // Many to many mapping

        /// <summary>
        /// Child Geofences (Many-to-Many) mapped by table [GeofenceTrakkerMap]
        /// </summary>
        public virtual ICollection<Geofence> Geofences { get; set; } // Many to many mapping

        /// <summary>
        /// Child GeofenceEvents where [GeofenceEvent].[TrakkerId] point to this entity (FK_TriggeredGeofenceTrakkerMap_Trakker)
        /// </summary>
        public virtual ICollection<GeofenceEvent> GeofenceEvents { get; set; } // GeofenceEvent.FK_TriggeredGeofenceTrakkerMap_Trakker

        /// <summary>
        /// Child Groups (Many-to-Many) mapped by table [TrakkerGroupMap]
        /// </summary>
        public virtual ICollection<Group> Groups { get; set; } // Many to many mapping

        /// <summary>
        /// Child Jobs (Many-to-Many) mapped by table [JobTrakkerMap]
        /// </summary>
        public virtual ICollection<Job> Jobs { get; set; } // Many to many mapping

        /// <summary>
        /// Child TrakkerEvents where [TrakkerEvent].[TrakkerId] point to this entity (FK_TrakkerEvent_Trakker)
        /// </summary>
        public virtual ICollection<TrakkerEvent> TrakkerEvents { get; set; } // TrakkerEvent.FK_TrakkerEvent_Trakker
        

        /// <summary>
        /// Child Vehicles (Many-to-Many) mapped by table [TrakkerVehicleMap]
        /// </summary>
        public virtual ICollection<Vehicle> Vehicles { get; set; } // Many to many mapping

        // Foreign keys

        /// <summary>
        /// Parent Customer pointed by [Trakker].([CustomerId]) (FK_Trakker_Customer)
        /// </summary>
        public virtual Customer Customer { get; set; } // FK_Trakker_Customer

        /// <summary>
        /// Parent Hardware pointed by [Trakker].([HardwareId]) (FK_Trakker_Hardware)
        /// </summary>
        public virtual Hardware Hardware { get; set; } // FK_Trakker_Hardware

        /// <summary>
        /// Parent Icon pointed by [Trakker].([IconId]) (FK_Trakker_Icon)
        /// </summary>
        public virtual Icon Icon { get; set; } // FK_Trakker_Icon

        /// <summary>
        /// Parent TrakkerEvent pointed by [Trakker].([LatestEventId]) (FK_Trakker_LatestEventId)
        /// </summary>
        public virtual TrakkerEvent LatestEvent { get; set; } // FK_Trakker_LatestEventId

        /// <summary>
        /// Parent TrakkerEvent pointed by [Trakker].([LatestPositionEventId]) (FK_Trakker_LatestPositionEventId)
        /// </summary>
        public virtual TrakkerEvent LatestPositionEvent { get; set; } // FK_Trakker_LatestPositionEventId

        public Trakker()
        {
            CreatedOn = DateTime.UtcNow;
            IconId = 42;
            IsActive = true;
            IsDeleted = false;
            AccountTrakkerMaps = new List<AccountTrakkerMap>();
            Assets = new List<Asset>();
            GeofenceEvents = new List<GeofenceEvent>();
            TrakkerEvents = new List<TrakkerEvent>();
            Categories = new List<Category>();
            Geofences = new List<Geofence>();
            Jobs = new List<Job>();
            Contacts = new List<Contact>();
            Groups = new List<Group>();
            Vehicles = new List<Vehicle>();
            LastContact = null;
        }
    }
}