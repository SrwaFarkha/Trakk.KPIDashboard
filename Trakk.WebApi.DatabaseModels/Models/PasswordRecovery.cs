using System;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class PasswordRecovery : IEntity
    {
        public Guid PasswordRecoveryId { get; set; } // PasswordRecoveryId (Primary key)
        public int AccountId { get; set; } // AccountId
        public DateTime ValidUntil { get; set; } // ValidUntil
        public bool IsUsed { get; set; } // IsUsed

        // Foreign keys

        /// <summary>
        /// Parent Account pointed by [PasswordRecovery].([AccountId]) (FK_PasswordRecovery_AccountId)
        /// </summary>
        public virtual Account Account { get; set; } // FK_PasswordRecovery_AccountId

        public PasswordRecovery()
        {
            IsUsed = false;
        }
    }
}