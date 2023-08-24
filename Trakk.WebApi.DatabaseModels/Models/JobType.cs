using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class JobType : IEntity
    {
        public int JobTypeId { get; set; } // JobTypeId (Primary key)
        public string Name { get; set; } // Name (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child Jobs where [Job].[JobTypeId] point to this entity (FK_Job_JobType)
        /// </summary>
        public virtual ICollection<Job> Jobs { get; set; } // Job.FK_Job_JobType

        public JobType()
        {
            Jobs = new List<Job>();
        }
    }
}