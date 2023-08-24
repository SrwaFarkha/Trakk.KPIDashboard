using System;
using System.Collections.Generic;
using Trakk.WebApi.Models;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class Hardware : IEntity
    {
        public int HardwareId { get; set; } // HardwareId (Primary key)
        public DateTime CreatedOn { get; set; } // CreatedOn
        public string GlobalDeviceId { get; set; } // GlobalDeviceId (length: 255)
        public string Icc { get; set; } // ICC (length: 255)
        public int HardwareTypeId { get; set; } // HardwareTypeId
        public int HardwareStatusId { get; set; } // HardwareStatusId
        public int? CustomerAdminId { get; set; } // CustomerAdminId
        public string Comment { get; set; } // Comment
        public int? HardwareConfigId { get; set; } // HardwareConfigId
        public int OffGridThresholdSeconds { get; set; }
        public int? CustomerId { get; set; } // CustomerId
        public DateTime? SentToCustomer { get; set; }
        public Enums.BillingType BillingType { get; set; }
        public Enums.FinancePartner FinancePartner { get; set; }

        // Reverse navigation

        /// <summary>
        /// Child Trakkers where [Trakker].[HardwareId] point to this entity (FK_Trakker_Hardware)
        /// </summary>
        public virtual ICollection<Trakker> Trakkers { get; set; } // Trakker.FK_Trakker_Hardware

        // Foreign keys

        /// <summary>
        /// Parent CustomerAdmin pointed by [Hardware].([CustomerAdminId]) (FK_Hardware_CustomerAdmin)
        /// </summary>
        public virtual CustomerAdmin CustomerAdmin { get; set; } // FK_Hardware_CustomerAdmin

        /// <summary>
        /// Parent HardwareConfig pointed by [Hardware].([HardwareConfigId]) (FK_Hardware_HardwareConfig)
        /// </summary>
        public virtual HardwareConfig HardwareConfig { get; set; } // FK_Hardware_HardwareConfig

        /// <summary>
        /// Parent HardwareStatu pointed by [Hardware].([HardwareStatusId]) (FK_Hardware_HardwareStatus)
        /// </summary>
        public virtual HardwareStatus HardwareStatus { get; set; } // FK_Hardware_HardwareStatus

        /// <summary>
        /// Parent HardwareType pointed by [Hardware].([HardwareTypeId]) (FK_Hardware_HardwareType)
        /// </summary>
        public virtual HardwareType HardwareType { get; set; } // FK_Hardware_HardwareType

        public virtual Customer Customer { get; set; }

        public Hardware()
        {
            CreatedOn = DateTime.UtcNow;
            HardwareStatusId = 1;
            Trakkers = new List<Trakker>();
            OffGridThresholdSeconds = 604800;
        }
    }
}