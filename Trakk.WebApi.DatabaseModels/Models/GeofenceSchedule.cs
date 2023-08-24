

// namespace Trakk.WebApi.DatabaseModels.Models
// {
//     public class GeofenceSchedule : IEntity
//     {
//         public int GeofenceScheduleId { get; set; } // GeofenceScheduleId (Primary key)
//         public int GeofenceId { get; set; } // GeofenceId
//         public string Schedule { get; set; } // Schedule (length: 50)
//
//         // Foreign keys
//
//         /// <summary>
//         /// Parent Geofence pointed by [GeofenceSchedule].([GeofenceId]) (FK_GeofenceSchedule_Geofence)
//         /// </summary>
//         public virtual Geofence Geofence { get; set; } // FK_GeofenceSchedule_Geofence
//     }
// }