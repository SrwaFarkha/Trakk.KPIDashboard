using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Trakk.WebApi.DatabaseModels.Models
{
    public partial class Geofence
    {
        [NotMapped] public ICollection<GeofenceEvent> UnitsInsideGeofence => GetUnitsInsideGeofence();
   
        public ICollection<GeofenceEvent> GetUnitsInsideGeofence() => GeofenceEvents.Where(x => x.LeftOn == null).ToList();

        [NotMapped]
        public string TimeZoneId
        {
            get => TimezoneId;
            set => TimezoneId = value;
        }
    }
}
