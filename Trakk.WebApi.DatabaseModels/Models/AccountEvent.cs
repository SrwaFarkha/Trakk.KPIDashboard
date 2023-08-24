using System;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class AccountEvent : IEntity
    {
        public int AccountEventId { get; set; } // AccountEventId (Primary key)
        public int AccountId { get; set; } // AccountId
        public int AccountEventTypeId { get; set; } // AccountEventTypeId
        public DateTime CreatedOn { get; set; } // CreatedOn
        public string? EventData { get; set; } // EventData

        // Foreign keys

        /// <summary>
        /// Parent Account pointed by [AccountEvent].([AccountId]) (FK_AccountEvent_Account)
        /// </summary>
        public virtual Account Account { get; set; } // FK_AccountEvent_Account

        /// <summary>
        /// Parent AccountEventType pointed by [AccountEvent].([AccountEventTypeId]) (FK_AccountEvent_EventType)
        /// </summary>
        public virtual AccountEventType AccountEventType { get; set; } // FK_AccountEvent_EventType
    }
}