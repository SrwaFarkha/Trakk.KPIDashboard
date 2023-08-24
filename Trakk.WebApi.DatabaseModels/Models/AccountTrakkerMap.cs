

namespace Trakk.WebApi.DatabaseModels.Models
{
    public class AccountTrakkerMap : IEntity
    {
        public int AccountId { get; set; } // AccountId (Primary key)
        public int TrakkerId { get; set; } // TrakkerId (Primary key)
        public bool IsFavorite { get; set; } // IsFavorite

        // Foreign keys

        /// <summary>
        /// Parent Account pointed by [AccountTrakkerMap].([AccountId]) (FK_AccountTrakkerMap_Account)
        /// </summary>
        public virtual Account Account { get; set; } // FK_AccountTrakkerMap_Account

        /// <summary>
        /// Parent Trakker pointed by [AccountTrakkerMap].([TrakkerId]) (FK_AccountTrakkerMap_Trakker)
        /// </summary>
        public virtual Trakker Trakker { get; set; } // FK_AccountTrakkerMap_Trakker

        public AccountTrakkerMap()
        {
            IsFavorite = false;
        }
    }
}