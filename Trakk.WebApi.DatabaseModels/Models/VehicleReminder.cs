using System;
using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class VehicleReminder : IEntity
    {
        public int VehicleReminderId { get; set; } // VehicleReminderId (Primary key)
        public int VehicleReminderTypeId { get; set; } // VehicleReminderTypeId
        public int? OdometerBreakpoint { get; set; } // OdometerBreakpoint
        public DateTime? ReminderDate { get; set; } // ReminderDate
        public bool IsTriggered { get; set; } // IsTriggered

        // Reverse navigation

        /// <summary>
        /// Child Contacts (Many-to-Many) mapped by table [VehicleReminderContactMap]
        /// </summary>
        public virtual ICollection<Contact> Contacts { get; set; } // Many to many mapping

        // Foreign keys

        /// <summary>
        /// Parent VehicleReminderType pointed by [VehicleReminder].([VehicleReminderTypeId]) (FK_VehicleReminder_Vehicle)
        /// </summary>
        public virtual VehicleReminderType VehicleReminderType { get; set; } // FK_VehicleReminder_Vehicle

        public VehicleReminder()
        {
            IsTriggered = false;
            Contacts = new List<Contact>();
        }
    }
}