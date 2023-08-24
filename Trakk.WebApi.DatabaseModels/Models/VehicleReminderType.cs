using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class VehicleReminderType : IEntity
    {
        public int VehicleReminderTypeId { get; set; } // VehicleReminderTypeId (Primary key)
        public string Name { get; set; } // Name (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child VehicleReminders where [VehicleReminder].[VehicleReminderTypeId] point to this entity (FK_VehicleReminder_Vehicle)
        /// </summary>
        public virtual ICollection<VehicleReminder> VehicleReminders { get; set; } // VehicleReminder.FK_VehicleReminder_Vehicle

        public VehicleReminderType()
        {
            VehicleReminders = new List<VehicleReminder>();
        }
    }
}