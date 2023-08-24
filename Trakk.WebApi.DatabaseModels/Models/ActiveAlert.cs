

namespace Trakk.WebApi.DatabaseModels.Models
{
    public class ActiveAlert : IEntity
    {
        public int ActiveAlertId { get; set; } // ActiveAlertId (Primary key)
        public int TrakkerEventId { get; set; } // TrakkerEventId
        public int? GeofenceEventId { get; set; } // GeofenceEventId

        // Foreign keys

        /// <summary>
        /// Parent GeofenceEvent pointed by [ActiveAlert].([GeofenceEventId]) (FK_ActiveAlert_GeofenceEvent)
        /// </summary>
        public virtual GeofenceEvent? GeofenceEvent { get; set; } // FK_ActiveAlert_GeofenceEvent

        /// <summary>
        /// Parent TrakkerEvent pointed by [ActiveAlert].([TrakkerEventId]) (FK_ActiveAlert_TrakkerEvent)
        /// </summary>
        public virtual TrakkerEvent TrakkerEvent { get; set; } // FK_ActiveAlert_TrakkerEvent
    }
}