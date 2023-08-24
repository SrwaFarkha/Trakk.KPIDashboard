using System;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class DriverEvent : IEntity
    {
        public int DriverEventId { get; set; } // DriverEventId (Primary key)
        public int DriverId { get; set; } // DriverId
        public int DriverEventTypeId { get; set; } // DriverEventTypeId
        public DateTime CreatedOn { get; set; } // CreatedOn
        public string EventData { get; set; } // EventData

        // Foreign keys

        /// <summary>
        /// Parent Driver pointed by [DriverEvent].([DriverId]) (FK_DriverEvent_Driver)
        /// </summary>
        public virtual Driver Driver { get; set; } // FK_DriverEvent_Driver

        /// <summary>
        /// Parent DriverEventType pointed by [DriverEvent].([DriverEventTypeId]) (FK_DriverEvent_DriverEventType)
        /// </summary>
        public virtual DriverEventType DriverEventType { get; set; } // FK_DriverEvent_DriverEventType

        public DriverEvent()
        {
            CreatedOn = DateTime.UtcNow;
        }
    }
}