using System;

#nullable disable

namespace Trakk.WebApi.DatabaseModels.Models.Partials
{
    public partial class TriggeredGeofenceTrakkerMap
    {
        public int GeofenceId { get; set; }
        public int TrakkerId { get; set; }
        public int TrakkerEventId { get; set; }
        public DateTime OccuredOn { get; set; }

        public virtual Geofence Geofence { get; set; }
        public virtual Trakker Trakker { get; set; }
        public virtual TrakkerEvent TrakkerEvent { get; set; }
    }
}
