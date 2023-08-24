using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class DriverEventType : IEntity
    {
        public int DriverEventTypeId { get; set; } // DriverEventTypeId (Primary key)
        public string Name { get; set; } // Name (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child DriverEvents where [DriverEvent].[DriverEventTypeId] point to this entity (FK_DriverEvent_DriverEventType)
        /// </summary>
        public virtual ICollection<DriverEvent> DriverEvents { get; set; } // DriverEvent.FK_DriverEvent_DriverEventType

        public DriverEventType()
        {
            DriverEvents = new List<DriverEvent>();
        }
    }
}