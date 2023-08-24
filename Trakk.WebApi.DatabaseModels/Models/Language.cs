using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class Language : IEntity
    {
        public int LanguageId { get; set; } // LanguageId (Primary key)
        public string Name { get; set; } // Name (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child Accounts where [Account].[LanguageId] point to this entity (FK_Account_Language)
        /// </summary>
        public virtual ICollection<Account> Accounts { get; set; } // Account.FK_Account_Language

        public Language()
        {
            Accounts = new List<Account>();
        }
    }
}