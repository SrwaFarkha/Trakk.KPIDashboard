using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class AccountEventType : IEntity
    {
        public int AccountEventTypeId { get; set; } // AccountEventTypeId (Primary key)
        public string Name { get; set; } // Name (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child AccountEvents where [AccountEvent].[AccountEventTypeId] point to this entity (FK_AccountEvent_EventType)
        /// </summary>
        public virtual ICollection<AccountEvent> AccountEvents { get; set; } // AccountEvent.FK_AccountEvent_EventType

        public AccountEventType()
        {
            AccountEvents = new List<AccountEvent>();
        }
    }
}