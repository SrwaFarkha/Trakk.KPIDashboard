

namespace Trakk.WebApi.DatabaseModels.Models
{
    public class ArchivedUnitsCustomer : IEntity
    {
        public int ArchivedUnitsCustomerId { get; set; } // ArchivedUnitsCustomerId (Primary key)
        public int? CustomerAdminId { get; set; } // CustomerAdminId
        public int CustomerId { get; set; } // CustomerId

        // Foreign keys

        /// <summary>
        /// Parent Customer pointed by [ArchivedUnitsCustomer].([CustomerId]) (FK_ArchivedUnitsCustomer_Customer)
        /// </summary>
        public virtual Customer Customer { get; set; } // FK_ArchivedUnitsCustomer_Customer

        /// <summary>
        /// Parent CustomerAdmin pointed by [ArchivedUnitsCustomer].([CustomerAdminId]) (FK_ArchivedUnitsCustomer_CustomerAdmin)
        /// </summary>
        public virtual CustomerAdmin? CustomerAdmin { get; set; } // FK_ArchivedUnitsCustomer_CustomerAdmin
    }
}