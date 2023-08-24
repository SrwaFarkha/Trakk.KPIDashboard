using System;
using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class GeofenceEvent : IEntity
    {
        public int GeofenceEventId { get; set; } // GeofenceEventId (Primary key)
        public int GeofenceId { get; set; } // GeofenceId
        public string GeofenceName { get; set; } // GeofenceName (length: 255)
        public int TrakkerId { get; set; } // TrakkerId
        public DateTime EnteredOn { get; set; } // EnteredOn
        public DateTime? LeftOn { get; set; } // LeftOn

        // Reverse navigation

        /// <summary>
        /// Child ActiveAlerts where [ActiveAlert].[GeofenceEventId] point to this entity (FK_ActiveAlert_GeofenceEvent)
        /// </summary>
        public virtual ICollection<ActiveAlert> ActiveAlerts { get; set; } // ActiveAlert.FK_ActiveAlert_GeofenceEvent

        // Foreign keys

        /// <summary>
        /// Parent Geofence pointed by [GeofenceEvent].([GeofenceId]) (FK_TriggeredGeofenceTrakkerMap_Geofence)
        /// </summary>
        public virtual Geofence Geofence { get; set; } // FK_TriggeredGeofenceTrakkerMap_Geofence

        /// <summary>
        /// Parent Trakker pointed by [GeofenceEvent].([TrakkerId]) (FK_TriggeredGeofenceTrakkerMap_Trakker)
        /// </summary>
        public virtual Trakker Trakker { get; set; } // FK_TriggeredGeofenceTrakkerMap_Trakker

        public GeofenceEvent()
        {
            ActiveAlerts = new List<ActiveAlert>();
        }
    }
}