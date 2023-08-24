using System;
using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class Job : IEntity
    {
        public int JobId { get; set; } // JobId (Primary key)
        public int? CustomerId { get; set; } // CustomerId
        public int? AccountId { get; set; } // AccountId
        public DateTime CreatedOn { get; set; } // CreatedOn
        public int JobTypeId { get; set; } // JobTypeId
        public int JobIntervalTypeId { get; set; } // JobIntervalTypeId
        public string? Name { get; set; } // Name (length: 255)
        public DateTime NextOccurrence { get; set; } // NextOccurrence
        public int? OdometerMeter { get; set; } // OdometerMeter
        public decimal? OperationTimeHours { get; set; } // OperationTimeHours
        public string? Arguments { get; set; } // Arguments
        public string? ArgumentType { get; set; } // ArgumentType

        // Reverse navigation


        public virtual ICollection<JobEmailAddress> EmailAddresses { get; set; }

        /// <summary>
        /// Child Assets (Many-to-Many) mapped by table [JobAssetMap]
        /// </summary>
        public virtual ICollection<Asset> Assets { get; set; } // Many to many mapping

        /// <summary>
        /// Child Contacts (Many-to-Many) mapped by table [JobContactMap]
        /// </summary>
        public virtual ICollection<Contact> Contacts { get; set; } // Many to many mapping

        /// <summary>
        /// Child Groups (Many-to-Many) mapped by table [JobGroupMap]
        /// </summary>
        public virtual ICollection<Group> Groups { get; set; } // Many to many mapping

        /// <summary>
        /// Child Trakkers (Many-to-Many) mapped by table [JobTrakkerMap]
        /// </summary>
        public virtual ICollection<Trakker> Trakkers { get; set; } // Many to many mapping

        // Foreign keys

        /// <summary>
        /// Parent Customer pointed by [Job].([CustomerId]) (FK_Job_Customer)
        /// </summary>
        public virtual Customer Customer { get; set; } // FK_Job_Customer

        public virtual Account Account { get; set; }

        /// <summary>
        /// Parent JobIntervalType pointed by [Job].([JobIntervalTypeId]) (FK_Job_JobIntervalType)
        /// </summary>
        public virtual JobIntervalType JobIntervalType { get; set; } // FK_Job_JobIntervalType

        /// <summary>
        /// Parent JobType pointed by [Job].([JobTypeId]) (FK_Job_JobType)
        /// </summary>
        public virtual JobType JobType { get; set; } // FK_Job_JobType

        public Job()
        {
            CreatedOn = DateTime.UtcNow;
            Assets = new List<Asset>();
            Contacts = new List<Contact>();
            Groups = new List<Group>();
            Trakkers = new List<Trakker>();
        }
    }
}