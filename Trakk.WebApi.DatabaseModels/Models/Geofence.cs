using System.Collections.Generic;
using NetTopologySuite.Geometries;
using Trakk.WebApi.DatabaseModels.Helpers;
using Trakk.WebApi.DatabaseModels.Models.VehicleSchedule_V2;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public partial class Geofence : IEntity
    {
        public int GeofenceId { get; set; } // GeofenceId (Primary key)
        public int CustomerId { get; set; } // CustomerId
        public int? ScheduleId { get; set; }
        public string Name { get; set; } // Name (length: 50)
        public int GeofenceTypeId { get; set; } // GeofenceTypeId
        public bool IsActive { get; set; } // IsActive
        public Geometry Geography { get; set; } // Geography
        public int? BufferRadius { get; set; } // BufferRadius
        public bool IsTimeControlled { get; set; } // IsTimeControlled
        public string TimezoneId { get; set; } // TimezoneId (length: 250)
        public bool ActiveForAllUnits { get; set; } // ActiveForAllUnits
        public Schedule Schedule { get; set; } = new Schedule();
        
        
        /// <summary>
        /// Checks if bufferRadius has value and returns a circle if so. Else returns the Geography as is. 
        /// </summary>
        /// <returns>Geometry with or without applied buffer radius, if buffer radius has value</returns>
        public Geometry GetGeometry() => BufferRadius.HasValue? Geography.Coordinate.ToCircle(BufferRadius.Value) : Geography;

        // Reverse navigation

        /// <summary>
        /// Child Contacts (Many-to-Many) mapped by table [GeofenceContactMap]
        /// </summary>
        public virtual ICollection<Contact> Contacts { get; set; } // Many to many mapping

        /// <summary>
        /// Child GeofenceEvents where [GeofenceEvent].[GeofenceId] point to this entity (FK_TriggeredGeofenceTrakkerMap_Geofence)
        /// </summary>
        public virtual ICollection<GeofenceEvent> GeofenceEvents { get; set; } // GeofenceEvent.FK_TriggeredGeofenceTrakkerMap_Geofence

        /// <summary>
        /// Child GeofenceSchedules where [GeofenceSchedule].[GeofenceId] point to this entity (FK_GeofenceSchedule_Geofence)
        /// </summary>
       // public virtual ICollection<GeofenceSchedule> GeofenceSchedules { get; set; } // GeofenceSchedule.FK_GeofenceSchedule_Geofence

        /// <summary>
        /// Child Groups (Many-to-Many) mapped by table [GeofenceGroupMap]
        /// </summary>
        public virtual ICollection<Group> Groups { get; set; } // Many to many mapping

        /// <summary>
        /// Child Trakkers (Many-to-Many) mapped by table [GeofenceTrakkerMap]
        /// </summary>
        public virtual ICollection<Trakker> Trakkers { get; set; } // Many to many mapping

        // Foreign keys

        /// <summary>
        /// Parent Customer pointed by [Geofence].([CustomerId]) (FK_Geofence_Customer)
        /// </summary>
        public virtual Customer Customer { get; set; } // FK_Geofence_Customer

        /// <summary>
        /// Parent GeofenceType pointed by [Geofence].([GeofenceTypeId]) (FK_Geofence_GeofenceType)
        /// </summary>
        public virtual GeofenceType GeofenceType { get; set; } // FK_Geofence_GeofenceType

        public Geofence()
        {
            IsActive = true;
            IsTimeControlled = false;
            TimezoneId = "UTC";
            ActiveForAllUnits = false;
            GeofenceEvents = new List<GeofenceEvent>();
            //GeofenceSchedules = new List<GeofenceSchedule>();
            Contacts = new List<Contact>();
            Groups = new List<Group>();
            Trakkers = new List<Trakker>();
        }
    }
}