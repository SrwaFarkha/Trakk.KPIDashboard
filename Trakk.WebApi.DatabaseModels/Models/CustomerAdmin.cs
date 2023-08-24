using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class CustomerAdmin : IEntity
    {
        public int CustomerAdminId { get; set; } // CustomerAdminId (Primary key)
        public string? Name { get; set; } // Name (length: 255)
        public string? ContactName { get; set; } // ContactName (length: 250)
        public string? ContactEmail { get; set; } // ContactEmail (length: 250)
        public string? ContactPhoneNumber { get; set; } // ContactPhoneNumber (length: 250)
        public bool IsLocked { get; set; } // IsLocked
        public bool CanRegisterHardware { get; set; }

        public virtual ICollection<SalesPerson> SalesPersons { get; set; }

        // Reverse navigation

        /// <summary>
        /// Child ArchivedUnitsCustomers where [ArchivedUnitsCustomer].[CustomerAdminId] point to this entity (FK_ArchivedUnitsCustomer_CustomerAdmin)
        /// </summary>
        public virtual ICollection<ArchivedUnitsCustomer> ArchivedUnitsCustomers { get; set; } // ArchivedUnitsCustomer.FK_ArchivedUnitsCustomer_CustomerAdmin

        /// <summary>
        /// Child Customers where [Customer].[CustomerAdminId] point to this entity (FK_Customer_CustomerAdminId)
        /// </summary>
        public virtual ICollection<Customer> Customers { get; set; } // Customer.FK_Customer_CustomerAdminId

        /// <summary>
        /// Child Hardwares where [Hardware].[CustomerAdminId] point to this entity (FK_Hardware_CustomerAdmin)
        /// </summary>
        public virtual ICollection<Hardware> Hardwares { get; set; } // Hardware.FK_Hardware_CustomerAdmin

        /// <summary>
        /// Child RootAccounts where [RootAccount].[CustomerAdminId] point to this entity (FK_RootAccount_CustomerAdmin)
        /// </summary>
        public virtual ICollection<RootAccount> RootAccounts { get; set; } // RootAccount.FK_RootAccount_CustomerAdmin

        public CustomerAdmin()
        {
            IsLocked = false;
            ArchivedUnitsCustomers = new List<ArchivedUnitsCustomer>();
            Customers = new List<Customer>();
            Hardwares = new List<Hardware>();
            RootAccounts = new List<RootAccount>();
            SalesPersons = new List<SalesPerson>();
        }
    }
}