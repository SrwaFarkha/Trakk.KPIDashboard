using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class RootAccountType : IEntity
    {
        public int RootAccountTypeId { get; set; } // RootAccountTypeId (Primary key)
        public string Name { get; set; } // Name (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child RootAccounts where [RootAccount].[RootAccountTypeId] point to this entity (FK_RootAccount_RootAccountType)
        /// </summary>
        public virtual ICollection<RootAccount> RootAccounts { get; set; } // RootAccount.FK_RootAccount_RootAccountType

        public RootAccountType()
        {
            RootAccounts = new List<RootAccount>();
        }
    }
}