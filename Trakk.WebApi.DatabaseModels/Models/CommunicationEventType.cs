using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class CommunicationEventType : IEntity
    {
        public int CommunicationEventTypeId { get; set; } // CommunicationEventTypeId (Primary key)
        public string Name { get; set; } // Name (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child CommunicationEvents where [CommunicationEvent].[CommunicationEventTypeId] point to this entity (FK_CommunicationEvent_CommunicationEventType)
        /// </summary>
        public virtual ICollection<CommunicationEvent> CommunicationEvents { get; set; } // CommunicationEvent.FK_CommunicationEvent_CommunicationEventType

        public CommunicationEventType()
        {
            CommunicationEvents = new List<CommunicationEvent>();
        }
    }
}