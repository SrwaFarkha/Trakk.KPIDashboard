#nullable disable

namespace Trakk.WebApi.DatabaseModels.Models.Partials
{
    public partial class GeofenceTrakkerMap
    {
        public int GeofenceId { get; set; }
        public int TrakkerId { get; set; }

        public virtual Geofence Geofence { get; set; }
        public virtual Trakker Trakker { get; set; }
    }
}
