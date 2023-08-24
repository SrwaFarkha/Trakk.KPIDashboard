using System.Collections.Generic;
using Trakk.WebApi.Models;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class Contact : IEntity
    {
        public int ContactId { get; set; } // ContactId (Primary key)
        public int CustomerId { get; set; } // CustomerId
        public string? Name { get; set; } // Name
        public string? Email { get; set; } // Email (length: 255)
        public string? Number { get; set; } // Number (length: 255)

        // Reverse navigation

        /// <summary>
        /// Child Accounts where [Account].[ContactId] point to this entity (FK_Account_Contact)
        /// </summary>
        public virtual ICollection<Account> Accounts { get; set; } // Account.FK_Account_Contact

        /// <summary>
        /// Child AlertTypes (Many-to-Many) mapped by table [ContactAlertMap]
        /// </summary>
        public virtual ICollection<Enums.AlertTypes> AlertTypes { get; set; } // Many to many mapping

        /// <summary>
        /// Child Geofences (Many-to-Many) mapped by table [GeofenceContactMap]
        /// </summary>
        public virtual ICollection<Geofence> Geofences { get; set; } // Many to many mapping

        /// <summary>
        /// Child Groups (Many-to-Many) mapped by table [ContactGroupMap]
        /// </summary>
        public virtual ICollection<Group> Groups { get; set; } // Many to many mapping

        /// <summary>
        /// Child Jobs (Many-to-Many) mapped by table [JobContactMap]
        /// </summary>
        public virtual ICollection<Job> Jobs { get; set; } // Many to many mapping

        /// <summary>
        /// Child Trakkers (Many-to-Many) mapped by table [TrakkerContactMap]
        /// </summary>
        public virtual ICollection<Trakker> Trakkers { get; set; } // Many to many mapping

        /// <summary>
        /// Child VehicleReminders (Many-to-Many) mapped by table [VehicleReminderContactMap]
        /// </summary>
        public virtual ICollection<VehicleReminder> VehicleReminders { get; set; } // Many to many mapping

        // Foreign keys

        /// <summary>
        /// Parent Customer pointed by [Contact].([CustomerId]) (FK_Contact_Customer)
        /// </summary>
        public virtual Customer Customer { get; set; } // FK_Contact_Customer

        public Contact()
        {
            Accounts = new List<Account>();
            AlertTypes = new List<Enums.AlertTypes>();
            Groups = new List<Group>();
            Geofences = new List<Geofence>();
            Jobs = new List<Job>();
            Trakkers = new List<Trakker>();
            VehicleReminders = new List<VehicleReminder>();
        }
    }
}