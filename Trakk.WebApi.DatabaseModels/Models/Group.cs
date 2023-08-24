using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class Group : IEntity
    {
        public int GroupId { get; set; } // GroupId (Primary key)
        public int CustomerId { get; set; } // CustomerId
        public string? Name { get; set; } // Name (length: 255)

        // Reverse navigation

        /// <summary>
        /// Child AccountGroupMaps where [AccountGroupMap].[GroupId] point to this entity (FK_AccountGroupMap_Group)
        /// </summary>
        public virtual ICollection<AccountGroupMap> AccountGroupMaps { get; set; } // AccountGroupMap.FK_AccountGroupMap_Group

        /// <summary>
        /// Child Contacts (Many-to-Many) mapped by table [ContactGroupMap]
        /// </summary>
        public virtual ICollection<Contact> Contacts { get; set; } // Many to many mapping

        /// <summary>
        /// Child Geofences (Many-to-Many) mapped by table [GeofenceGroupMap]
        /// </summary>
        public virtual ICollection<Geofence> Geofences { get; set; } // Many to many mapping

        /// <summary>
        /// Child Jobs (Many-to-Many) mapped by table [JobGroupMap]
        /// </summary>
        public virtual ICollection<Job> Jobs { get; set; } // Many to many mapping

        /// <summary>
        /// Child Trakkers (Many-to-Many) mapped by table [TrakkerGroupMap]
        /// </summary>
        public virtual ICollection<Trakker> Trakkers { get; set; } // Many to many mapping

        // Foreign keys

        /// <summary>
        /// Parent Customer pointed by [Group].([CustomerId]) (FK_Group_Customer)
        /// </summary>
        public virtual Customer Customer { get; set; } = null; // FK_Group_Customer

        public Group()
        {
            AccountGroupMaps = new List<AccountGroupMap>();
            Contacts = new List<Contact>();
            Geofences = new List<Geofence>();
            Jobs = new List<Job>();
            Trakkers = new List<Trakker>();
        }
    }
}