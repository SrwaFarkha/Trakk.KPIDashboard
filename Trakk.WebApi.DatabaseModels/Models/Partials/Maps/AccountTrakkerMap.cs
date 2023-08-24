#nullable disable

namespace Trakk.WebApi.DatabaseModels.Models.Partials
{
    public partial class AccountTrakkerMap
    {
        public int AccountId { get; set; }
        public int TrakkerId { get; set; }
        public bool IsFavorite { get; set; }

        public virtual Account Account { get; set; }
        public virtual Trakker Trakker { get; set; }
    }
}
