// using System;
// using System.Collections.Generic;
//
// namespace Trakk.WebApi.DatabaseModels.Models
// {
//     public class VehicleEvent : IEntity
//     {
//         public int VehicleEventId { get; set; } // VehicleEventId (Primary key)
//         public int VehicleId { get; set; } // VehicleId
//         public DateTime CreatedOn { get; set; } // CreatedOn
//         public int VehicleEventTypeId { get; set; } // VehicleEventTypeId
//         public DateTime? FromDateTime { get; set; } // FromDateTime
//         public int? FromPositionId { get; set; } // FromPositionId
//         public DateTime? ToDateTime { get; set; } // ToDateTime
//         public int? ToPositionId { get; set; } // ToPositionId
//         public int? RouteId { get; set; } // RouteId
//         public int? DistanceMeter { get; set; } // DistanceMeter
//         public int? OdometerMeter { get; set; } // OdometerMeter
//         public string Driver { get; set; } // Driver (length: 256)
//         public bool? IsPrivate { get; set; } // IsPrivate
//         public string Comment { get; set; } // Comment (length: 255)
//         public decimal? Cost { get; set; } // Cost
//         public string CostData { get; set; } // CostData
//         public string FromAddress { get; set; } // FromAddress (length: 255)
//         public string ToAddress { get; set; } // ToAddress (length: 255)
//         public int? ParentVehicleEventId { get; set; } // ParentVehicleEventId
//
//         // Reverse navigation
//
//         /// <summary>
//         /// Child VehicleEvents (Many-to-Many) mapped by table [TripCongestionTaxMap]
//         /// </summary>
//         public virtual ICollection<VehicleEvent> VehicleEvents_CongestionTaxVehicleEventId { get; set; } // Many to many mapping
//
//         /// <summary>
//         /// Child VehicleEvents where [VehicleEvent].[ParentVehicleEventId] point to this entity (FK_VehicleEvent_Parent)
//         /// </summary>
//         public virtual ICollection<VehicleEvent> VehicleEvents_ParentVehicleEventId { get; set; } // VehicleEvent.FK_VehicleEvent_Parent
//
//         /// <summary>
//         /// Child VehicleEvents (Many-to-Many) mapped by table [TripCongestionTaxMap]
//         /// </summary>
//         public virtual ICollection<VehicleEvent> VehicleEvents_TripVehicleEventId { get; set; } // Many to many mapping
//
//         /// <summary>
//         /// Child VehicleEventPositionMaps where [VehicleEventPositionMap].[VehicleEventId] point to this entity (FK_VehicleEventPositionMap_VehicleEvent)
//         /// </summary>
//         public virtual ICollection<VehicleEventPositionMap> VehicleEventPositionMaps { get; set; } // VehicleEventPositionMap.FK_VehicleEventPositionMap_VehicleEvent
//
//         // Foreign keys
//
//         /// <summary>
//         /// Parent Position pointed by [VehicleEvent].([FromPositionId]) (FK_VehicleEvent_FromPosition)
//         /// </summary>
//         public virtual Position FromPosition { get; set; } // FK_VehicleEvent_FromPosition
//
//         /// <summary>
//         /// Parent Position pointed by [VehicleEvent].([ToPositionId]) (FK_VehicleEvent_ToPosition)
//         /// </summary>
//         public virtual Position ToPosition { get; set; } // FK_VehicleEvent_ToPosition
//
//         /// <summary>
//         /// Parent Route pointed by [VehicleEvent].([RouteId]) (FK_VehicleEvent_Route)
//         /// </summary>
//         public virtual Route Route { get; set; } // FK_VehicleEvent_Route
//
//         /// <summary>
//         /// Parent Vehicle pointed by [VehicleEvent].([VehicleId]) (FK_VehicleEvent_Vehicle)
//         /// </summary>
//         public virtual Vehicle Vehicle { get; set; } // FK_VehicleEvent_Vehicle
//
//         /// <summary>
//         /// Parent VehicleEvent pointed by [VehicleEvent].([ParentVehicleEventId]) (FK_VehicleEvent_Parent)
//         /// </summary>
//         public virtual VehicleEvent ParentVehicleEvent { get; set; } // FK_VehicleEvent_Parent
//
//         /// <summary>
//         /// Parent VehicleEventType pointed by [VehicleEvent].([VehicleEventTypeId]) (FK_VehicleEvent_VehicleEventType)
//         /// </summary>
//         public virtual VehicleEventType VehicleEventType { get; set; } // FK_VehicleEvent_VehicleEventType
//
//         public VehicleEvent()
//         {
//             CreatedOn = DateTime.UtcNow;
//             Driver = "";
//             VehicleEvents_ParentVehicleEventId = new List<VehicleEvent>();
//             VehicleEventPositionMaps = new List<VehicleEventPositionMap>();
//             VehicleEvents_CongestionTaxVehicleEventId = new List<VehicleEvent>();
//             VehicleEvents_TripVehicleEventId = new List<VehicleEvent>();
//         }
//     }
// }