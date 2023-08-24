using System;
using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class Account : IEntity
    {
        public int AccountId { get; set; } // AccountId (Primary key)
        public int CustomerId { get; set; } // CustomerId
        public Guid Guid { get; set; } // GUID
        public string Name { get; set; } // Name (length: 255)
        public string PasswordHash { get; set; } // PasswordHash (length: 255)
        public string? Email { get; set; } // Email (length: 256)
        public int AccountRoleId { get; set; } // AccountRoleId
        public DateTime CreatedOn { get; set; } // CreatedOn
        public DateTime? UpdatedOn { get; set; } // UpdatedOn
        public DateTime? ValidUntil { get; set; } // ValidUntil
        public string TimeZoneId { get; set; } // TimeZoneId (length: 250)
        public bool IsEmailConfirmed { get; set; } // IsEmailConfirmed
        public bool? IsActive { get; set; } // IsActive
        public bool IsLockedOut { get; set; } // IsLockedOut
        public bool IsDeleted { get; set; } // IsDeleted
        public int LanguageId { get; set; } // LanguageId
        public int IconSizePixels { get; set; } // IconSizePixels
        public string SpeedUnit { get; set; } // SpeedUnit (length: 10)
        public decimal? HomeLatitude { get; set; } // HomeLatitude
        public decimal? HomeLongitude { get; set; } // HomeLongitude
        public int ContactId { get; set; } // ContactId
        public string LoginName { get; set; } // LoginName (length: 256)
        public string? PasswordEncrypted { get; set; } // PasswordEncrypted

        // Reverse navigation

        /// <summary>
        /// Parent (One-to-One) Account pointed by [DriverSettings].[AccountId] (FK_DriverSettings_Account)
        /// </summary>
        public virtual DriverSetting? DriverSetting { get; set; } // DriverSettings.FK_DriverSettings_Account

        /// <summary>
        /// Child AccountConfirmations where [AccountConfirmation].[AccountId] point to this entity (FK_AccountConfirmation_Account)
        /// </summary>
        public virtual ICollection<AccountConfirmation> AccountConfirmations { get; set; } // AccountConfirmation.FK_AccountConfirmation_Account

        /// <summary>
        /// Child AccountEvents where [AccountEvent].[AccountId] point to this entity (FK_AccountEvent_Account)
        /// </summary>
        public virtual ICollection<AccountEvent> AccountEvents { get; set; } // AccountEvent.FK_AccountEvent_Account

        /// <summary>
        /// Child AccountGroupMaps where [AccountGroupMap].[AccountId] point to this entity (FK_AccountGroupMap_Account)
        /// </summary>
        public virtual ICollection<AccountGroupMap> AccountGroupMaps { get; set; } // AccountGroupMap.FK_AccountGroupMap_Account

        /// <summary>
        /// Child AccountRightMaps where [AccountRightMap].[AccountId] point to this entity (FK_AccountRightMap_Account)
        /// </summary>
        public virtual ICollection<AccountRightMap> AccountRightMaps { get; set; } // AccountRightMap.FK_AccountRightMap_Account

        /// <summary>
        /// Child AccountTrakkerMaps where [AccountTrakkerMap].[AccountId] point to this entity (FK_AccountTrakkerMap_Account)
        /// </summary>
        public virtual ICollection<AccountTrakkerMap> AccountTrakkerMaps { get; set; } // AccountTrakkerMap.FK_AccountTrakkerMap_Account

        /// <summary>
        /// Child ChangeEmailTickets where [ChangeEmailTicket].[AccountId] point to this entity (FK_ChangeEmailTicket_Account)
        /// </summary>
        public virtual ICollection<ChangeEmailTicket> ChangeEmailTickets { get; set; } // ChangeEmailTicket.FK_ChangeEmailTicket_Account

        /// <summary>
        /// Child CommunicationEvents where [CommunicationEvent].[AccountId] point to this entity (FK_CommunicationEvent_Account)
        /// </summary>
        public virtual ICollection<CommunicationEvent> CommunicationEvents { get; set; } // CommunicationEvent.FK_CommunicationEvent_Account

        /// <summary>
        /// Child Drivers where [Driver].[AccountId] point to this entity (FK_Driver_AccountId)
        /// </summary>
        public virtual ICollection<Driver> Drivers { get; set; } // Driver.FK_Driver_AccountId

        /// <summary>
        /// Child PasswordRecoveries where [PasswordRecovery].[AccountId] point to this entity (FK_PasswordRecovery_AccountId)
        /// </summary>
        public virtual ICollection<PasswordRecovery> PasswordRecoveries { get; set; } // PasswordRecovery.FK_PasswordRecovery_AccountId

        public virtual ICollection<Job> Jobs { get; set; } // FK_Account_Customer

        // Foreign keys

        /// <summary>
        /// Parent AccountRole pointed by [Account].([AccountRoleId]) (FK_Account_UserRole)
        /// </summary>
        public virtual AccountRole AccountRole { get; set; } // FK_Account_UserRole

        /// <summary>
        /// Parent Contact pointed by [Account].([ContactId]) (FK_Account_Contact)
        /// </summary>
        public virtual Contact Contact { get; set; } // FK_Account_Contact

        /// <summary>
        /// Parent Customer pointed by [Account].([CustomerId]) (FK_Account_Customer)
        /// </summary>
        public virtual Customer Customer { get; set; } // FK_Account_Customer

        /// <summary>
        /// Parent Language pointed by [Account].([LanguageId]) (FK_Account_Language)
        /// </summary>
        public virtual Language Language { get; set; } // FK_Account_Language

        public Account()
        {
            TimeZoneId = "UTC";
            IsEmailConfirmed = false;
            IsActive = true;
            IsLockedOut = false;
            IsDeleted = false;
            LanguageId = 0;
            IconSizePixels = 32;
            SpeedUnit = "kmh";
            AccountConfirmations = new List<AccountConfirmation>();
            AccountEvents = new List<AccountEvent>();
            AccountGroupMaps = new List<AccountGroupMap>();
            AccountRightMaps = new List<AccountRightMap>();
            AccountTrakkerMaps = new List<AccountTrakkerMap>();
            ChangeEmailTickets = new List<ChangeEmailTicket>();
            CommunicationEvents = new List<CommunicationEvent>();
            Drivers = new List<Driver>();
            PasswordRecoveries = new List<PasswordRecovery>();
        }
    }
}