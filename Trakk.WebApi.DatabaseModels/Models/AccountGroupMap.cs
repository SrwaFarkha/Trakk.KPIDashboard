

namespace Trakk.WebApi.DatabaseModels.Models
{
    public class AccountGroupMap : IEntity
    {
        public int AccountId { get; set; } // AccountId (Primary key)
        public int GroupId { get; set; } // GroupId (Primary key)
        public bool Access { get; set; } // Access
        public bool IsFavorite { get; set; } // IsFavorite
        public bool IsPersonal { get; set; }

        // Foreign keys

        /// <summary>
        /// Parent Account pointed by [AccountGroupMap].([AccountId]) (FK_AccountGroupMap_Account)
        /// </summary>
        public virtual Account Account { get; set; } // FK_AccountGroupMap_Account

        /// <summary>
        /// Parent Group pointed by [AccountGroupMap].([GroupId]) (FK_AccountGroupMap_Group)
        /// </summary>
        public virtual Group Group { get; set; } // FK_AccountGroupMap_Group

        public AccountGroupMap()
        {
            IsFavorite = false;
            IsPersonal = false;
        }
    }
}