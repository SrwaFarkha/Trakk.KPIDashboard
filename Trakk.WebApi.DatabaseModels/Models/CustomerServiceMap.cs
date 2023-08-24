using System;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class CustomerServiceMap : IEntity
    {
        public int CustomerId { get; set; } // CustomerId (Primary key)
        public int ServiceId { get; set; } // ServiceId (Primary key)
        public bool IsActive { get; set; } // IsActive
        public DateTime? ValidUntil { get; set; } // ValidUntil
        public string ValueData { get; set; } // ValueData

        // Foreign keys

        /// <summary>
        /// Parent Customer pointed by [CustomerServiceMap].([CustomerId]) (FK_CustomerServiceMap_UserAccount)
        /// </summary>
        public virtual Customer Customer { get; set; } // FK_CustomerServiceMap_UserAccount

        /// <summary>
        /// Parent Service pointed by [CustomerServiceMap].([ServiceId]) (FK_CustomerServiceMap_Service)
        /// </summary>
        public virtual Service Service { get; set; } // FK_CustomerServiceMap_Service

        public CustomerServiceMap()
        {
            IsActive = true;
        }
    }
}