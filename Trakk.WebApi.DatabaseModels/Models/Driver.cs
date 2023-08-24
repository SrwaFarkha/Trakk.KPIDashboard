using System;
using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class Driver : IEntity
    {
        public int DriverId { get; set; } // DriverId (Primary key)
        public int CustomerId { get; set; } // CustomerId
        public string Name { get; set; } // Name (length: 255)
        public int? AccountId { get; set; } // AccountId
        public DateTime CreatedOn { get; set; } // CreatedOn

        // Reverse navigation

        /// <summary>
        /// Child DriverEvents where [DriverEvent].[DriverId] point to this entity (FK_DriverEvent_Driver)
        /// </summary>
        public virtual ICollection<DriverEvent> DriverEvents { get; set; } // DriverEvent.FK_DriverEvent_Driver

        // Foreign keys

        /// <summary>
        /// Parent Account pointed by [Driver].([AccountId]) (FK_Driver_AccountId)
        /// </summary>
        public virtual Account Account { get; set; } // FK_Driver_AccountId

        /// <summary>
        /// Parent Customer pointed by [Driver].([CustomerId]) (FK_Driver_Customer)
        /// </summary>
        public virtual Customer Customer { get; set; } // FK_Driver_Customer

        public Driver()
        {
            CreatedOn = DateTime.UtcNow;
            DriverEvents = new List<DriverEvent>();
        }
    }
}