using System;
using System.Collections.Generic;
using Trakk.WebApi.Models;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class Customer : IEntity
    {
        public int CustomerId { get; set; } // CustomerId (Primary key)
        public string Name { get; set; } // Name (length: 250)
        public string? Information { get; set; } // Information
        public DateTime CreatedOn { get; set; } // CreatedOn
        public DateTime? UpdatedOn { get; set; } // UpdatedOn
        public int? CustomerAdminId { get; set; } // CustomerAdminId
        public bool IsLocked { get; set; } // IsLocked
        public string? Comment { get; set; } // Comment
        public string? Address { get; set; } // Address (length: 255)
        public string? ZipCode { get; set; } // ZipCode (length: 255)
        public string? City { get; set; } // City (length: 255)
        public string? Country { get; set; } // Country (length: 255)
        public int? SalesPersonId { get; set; }
        public List<ExternalAccessMap> ExternalAccessMaps { get; set; } = new List<ExternalAccessMap>();

        public List<CustomerFeature> CustomerFeatures { get; set; }


        public List<CustomerFuelPrice> FuelTypePrices { get; set; }

        // Reverse navigation

        /// <summary>
        /// Child Accounts where [Account].[CustomerId] point to this entity (FK_Account_Customer)
        /// </summary>
        public virtual ICollection<Account> Accounts { get; set; } // Account.FK_Account_Customer

        /// <summary>
        /// Child ArchivedUnitsCustomers where [ArchivedUnitsCustomer].[CustomerId] point to this entity (FK_ArchivedUnitsCustomer_Customer)
        /// </summary>
        public virtual ICollection<ArchivedUnitsCustomer> ArchivedUnitsCustomers { get; set; } // ArchivedUnitsCustomer.FK_ArchivedUnitsCustomer_Customer

        /// <summary>
        /// Child Contacts where [Contact].[CustomerId] point to this entity (FK_Contact_Customer)
        /// </summary>
        public virtual ICollection<Contact> Contacts { get; set; } // Contact.FK_Contact_Customer

        /// <summary>
        /// Child CustomerServiceMaps where [CustomerServiceMap].[CustomerId] point to this entity (FK_CustomerServiceMap_UserAccount)
        /// </summary>
        public virtual ICollection<CustomerServiceMap> CustomerServiceMaps { get; set; } // CustomerServiceMap.FK_CustomerServiceMap_UserAccount

        /// <summary>
        /// Child Drivers where [Driver].[CustomerId] point to this entity (FK_Driver_Customer)
        /// </summary>
        public virtual ICollection<Driver> Drivers { get; set; } // Driver.FK_Driver_Customer

        /// <summary>
        /// Child Geofences where [Geofence].[CustomerId] point to this entity (FK_Geofence_Customer)
        /// </summary>
        public virtual ICollection<Geofence> Geofences { get; set; } // Geofence.FK_Geofence_Customer

        /// <summary>
        /// Child Groups where [Group].[CustomerId] point to this entity (FK_Group_Customer)
        /// </summary>
        public virtual ICollection<Group> Groups { get; set; } // Group.FK_Group_Customer

        /// <summary>
        /// Child Jobs where [Job].[CustomerId] point to this entity (FK_Job_Customer)
        /// </summary>
        public virtual ICollection<Job> Jobs { get; set; } // Job.FK_Job_Customer

        /// <summary>
        /// Child Mapzones where [Mapzone].[CustomerId] point to this entity (FK_Mapzone_Customer)
        /// </summary>
        public virtual ICollection<Mapzone> Mapzones { get; set; } // Mapzone.FK_Mapzone_Customer

        /// <summary>
        /// Child Trakkers where [Trakker].[CustomerId] point to this entity (FK_Trakker_Customer)
        /// </summary>
        public virtual ICollection<Trakker> Trakkers { get; set; } // Trakker.FK_Trakker_Customer

        /// <summary>
        /// Child Vehicles where [Vehicle].[CustomerId] point to this entity (FK_Vehicle_Customer)
        /// </summary>
        public virtual ICollection<Vehicle> Vehicles { get; set; } // Vehicle.FK_Vehicle_Customer

        public virtual ICollection<Hardware> Hardwares { get; set; }

        // Foreign keys

        /// <summary>
        /// Parent CustomerAdmin pointed by [Customer].([CustomerAdminId]) (FK_Customer_CustomerAdminId)
        /// </summary>
        public virtual CustomerAdmin? CustomerAdmin { get; set; } // FK_Customer_CustomerAdminId
        public virtual SalesPerson? SalesPerson { get; set; }

        public Customer()
        {
            CreatedOn = DateTime.UtcNow;
            IsLocked = false;
            Accounts = new List<Account>();
            ArchivedUnitsCustomers = new List<ArchivedUnitsCustomer>();
            Contacts = new List<Contact>();
            CustomerServiceMaps = new List<CustomerServiceMap>();
            Drivers = new List<Driver>();
            Geofences = new List<Geofence>();
            Groups = new List<Group>();
            Jobs = new List<Job>();
            Mapzones = new List<Mapzone>();
            Trakkers = new List<Trakker>();
            Vehicles = new List<Vehicle>();
            Hardwares = new List<Hardware>();
            CustomerFeatures = new List<CustomerFeature>();
        }
    }
}