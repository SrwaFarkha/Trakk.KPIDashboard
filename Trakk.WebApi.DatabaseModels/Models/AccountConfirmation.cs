using System;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class AccountConfirmation : IEntity
    {
        public Guid AccountConfirmationId { get; set; } // AccountConfirmationId (Primary key)
        public int AccountId { get; set; } // AccountId (Primary key)

        // Foreign keys

        /// <summary>
        /// Parent Account pointed by [AccountConfirmation].([AccountId]) (FK_AccountConfirmation_Account)
        /// </summary>
        public virtual Account Account { get; set; } // FK_AccountConfirmation_Account
    }
}