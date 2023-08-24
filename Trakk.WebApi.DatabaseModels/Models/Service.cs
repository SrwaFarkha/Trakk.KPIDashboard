using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class Service : IEntity
    {
        public int ServiceId { get; set; } // ServiceId (Primary key)
        public string Name { get; set; } // Name (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child CustomerServiceMaps where [CustomerServiceMap].[ServiceId] point to this entity (FK_CustomerServiceMap_Service)
        /// </summary>
        public virtual ICollection<CustomerServiceMap> CustomerServiceMaps { get; set; } // CustomerServiceMap.FK_CustomerServiceMap_Service

        public Service()
        {
            CustomerServiceMaps = new List<CustomerServiceMap>();
        }
    }
}