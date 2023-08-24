// using System.Collections.Generic;
//
// namespace Trakk.WebApi.DatabaseModels.Models
// {
//     public class VehicleEventType : IEntity
//     {
//         public int VehicleEventTypeId { get; set; } // VehicleEventTypeId (Primary key)
//         public string Name { get; set; } // Name (length: 50)
//
//         // Reverse navigation
//
//         /// <summary>
//         /// Child VehicleEvents where [VehicleEvent].[VehicleEventTypeId] point to this entity (FK_VehicleEvent_VehicleEventType)
//         /// </summary>
//         public virtual ICollection<VehicleEvent> VehicleEvents { get; set; } // VehicleEvent.FK_VehicleEvent_VehicleEventType
//
//         public VehicleEventType()
//         {
//             VehicleEvents = new List<VehicleEvent>();
//         }
//     }
// }