#nullable disable

namespace Trakk.WebApi.DatabaseModels.Models.Partials
{
    public partial class CategoryTrakkerMap
    {
        public int CategoryId { get; set; }
        public int TrakkerId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Trakker Trakker { get; set; }
    }
}
