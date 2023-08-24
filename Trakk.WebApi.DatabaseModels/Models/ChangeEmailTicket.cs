using System;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class ChangeEmailTicket : IEntity
    {
        public int ChangeEmailTicketId { get; set; } // ChangeEmailTicketId (Primary key)
        public int AccountId { get; set; } // AccountId
        public string OldEmail { get; set; } // OldEmail (length: 256)
        public string NewEmail { get; set; } // NewEmail (length: 256)
        public bool IsUsed { get; set; } // IsUsed
        public DateTime ValidUntil { get; set; } // ValidUntil
        public Guid Verification { get; set; } // Verification

        // Foreign keys

        /// <summary>
        /// Parent Account pointed by [ChangeEmailTicket].([AccountId]) (FK_ChangeEmailTicket_Account)
        /// </summary>
        public virtual Account Account { get; set; } // FK_ChangeEmailTicket_Account

        public ChangeEmailTicket()
        {
            IsUsed = false;
            ValidUntil = DateTime.UtcNow;
            Verification = Guid.NewGuid();
        }
    }
}