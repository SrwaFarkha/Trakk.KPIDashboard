using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class JobIntervalType : IEntity
    {
        public int JobIntervalTypeId { get; set; } // JobIntervalTypeId (Primary key)
        public string Name { get; set; } // Name (length: 255)

        // Reverse navigation

        /// <summary>
        /// Child Jobs where [Job].[JobIntervalTypeId] point to this entity (FK_Job_JobIntervalType)
        /// </summary>
        public virtual ICollection<Job> Jobs { get; set; } // Job.FK_Job_JobIntervalType

        public JobIntervalType()
        {
            Jobs = new List<Job>();
        }
    }
}