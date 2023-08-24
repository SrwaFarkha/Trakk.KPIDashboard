using System.Collections.Generic;

namespace Trakk.WebApi.DatabaseModels.Models
{
    public class AccountRole : IEntity
    {
        public int AccountRoleId { get; set; } // AccountRoleId (Primary key)
        public string Name { get; set; } // Name (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child Accounts where [Account].[AccountRoleId] point to this entity (FK_Account_UserRole)
        /// </summary>
        public virtual ICollection<Account> Accounts { get; set; } // Account.FK_Account_UserRole

        public AccountRole()
        {
            Accounts = new List<Account>();
        }
    }
}