using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class AlertType : IEntity
    {
        public int AlertTypeId { get; set; } // AlertTypeId (Primary key)
        public string Name { get; set; } // Name (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child Contacts (Many-to-Many) mapped by table [ContactAlertMap]
        /// </summary>
        public virtual ICollection<Contact> Contacts { get; set; } // Many to many mapping

        /// <summary>
        /// Child TrakkerEvents where [TrakkerEvent].[AlertTypeId] point to this entity (FK_TrakkerEvent_AlertType)
        /// </summary>
        public virtual ICollection<TrakkerEvent> TrakkerEvents { get; set; } // TrakkerEvent.FK_TrakkerEvent_AlertType

        public AlertType()
        {
            TrakkerEvents = new List<TrakkerEvent>();
            Contacts = new List<Contact>();
        }
    }
}