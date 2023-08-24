// using System;
//
// namespace Trakk.WebApi.DatabaseModels.Models
// {
//     public class VehicleEventPositionMap : IEntity
//     {
//         public int Id { get; set; } // Id (Primary key)
//         public int VehicleEventId { get; set; } // VehicleEventId
//         public int PositionId { get; set; } // PositionId
//         public DateTime OccuredOn { get; set; } // OccuredOn
//
//         // Foreign keys
//
//         /// <summary>
//         /// Parent Position pointed by [VehicleEventPositionMap].([PositionId]) (FK_VehicleEventPositionMap_PositionId)
//         /// </summary>
//         public virtual Position Position { get; set; } // FK_VehicleEventPositionMap_PositionId
//
//         /// <summary>
//         /// Parent VehicleEvent pointed by [VehicleEventPositionMap].([VehicleEventId]) (FK_VehicleEventPositionMap_VehicleEvent)
//         /// </summary>
//         public virtual VehicleEvent VehicleEvent { get; set; } // FK_VehicleEventPositionMap_VehicleEvent
//     }
// }