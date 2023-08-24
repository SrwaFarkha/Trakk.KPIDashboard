#nullable disable

namespace Trakk.WebApi.DatabaseModels.Models.Partials
{
    public partial class GeofenceGroupMap
    {
        public int GeofenceId { get; set; }
        public int GroupId { get; set; }

        public virtual Geofence Geofence { get; set; }
        public virtual Group Group { get; set; }
    }
}
