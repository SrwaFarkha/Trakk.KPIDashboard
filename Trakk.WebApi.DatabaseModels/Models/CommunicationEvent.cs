using System;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class CommunicationEvent : IEntity
    {
        public int CommunicationEventId { get; set; } // CommunicationEventId (Primary key)
        public int AccountId { get; set; } // AccountId
        public DateTime CreatedOn { get; set; } // CreatedOn
        public int CommunicationEventTypeId { get; set; } // CommunicationEventTypeId
        public string Sender { get; set; } // Sender (length: 256)
        public string Receiver { get; set; } // Receiver (length: 256)
        public string? Subject { get; set; } // Subject (length: 255)
        public string? Message { get; set; } // Message
        public bool IsSent { get; set; } // IsSent

        // Foreign keys

        /// <summary>
        /// Parent Account pointed by [CommunicationEvent].([AccountId]) (FK_CommunicationEvent_Account)
        /// </summary>
        public virtual Account Account { get; set; } // FK_CommunicationEvent_Account

        /// <summary>
        /// Parent CommunicationEventType pointed by [CommunicationEvent].([CommunicationEventTypeId]) (FK_CommunicationEvent_CommunicationEventType)
        /// </summary>
        public virtual CommunicationEventType CommunicationEventType { get; set; } // FK_CommunicationEvent_CommunicationEventType
    }
}