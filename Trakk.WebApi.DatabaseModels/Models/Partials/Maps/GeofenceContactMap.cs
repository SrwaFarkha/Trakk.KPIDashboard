#nullable disable

namespace Trakk.WebApi.DatabaseModels.Models.Partials
{
    public partial class GeofenceContactMap
    {
        public int GeofenceId { get; set; }
        public int ContactId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Geofence Geofence { get; set; }
    }
}
