using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class GeofenceType : IEntity
    {
        public int GeofenceTypeId { get; set; } // GeofenceTypeId (Primary key)
        public string Name { get; set; } // Name (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child Geofences where [Geofence].[GeofenceTypeId] point to this entity (FK_Geofence_GeofenceType)
        /// </summary>
        public virtual ICollection<Geofence> Geofences { get; set; } // Geofence.FK_Geofence_GeofenceType

        public GeofenceType()
        {
            Geofences = new List<Geofence>();
        }
    }
}