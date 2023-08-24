//
//
// namespace Trakk.WebApi.DatabaseModels.Models
// {
//     public class VehicleSchedule : IEntity
//     {
//         public int VehicleScheduleId { get; set; } // VehicleScheduleId (Primary key)
//         public int VehicleId { get; set; } // VehicleId
//         public string Schedule { get; set; } // Schedule (length: 50)
//
//         // Foreign keys
//
//         /// <summary>
//         /// Parent Vehicle pointed by [VehicleSchedule].([VehicleId]) (FK_VehicleScheduleVehicle)
//         /// </summary>
//         public virtual Vehicle Vehicle { get; set; } // FK_VehicleScheduleVehicle
//     }
// }