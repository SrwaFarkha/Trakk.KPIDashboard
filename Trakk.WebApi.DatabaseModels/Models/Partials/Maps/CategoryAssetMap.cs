#nullable disable

namespace Trakk.WebApi.DatabaseModels.Models.Partials
{
    public partial class CategoryAssetMap
    {
        public int CategoryId { get; set; }
        public int AssetId { get; set; }

        public virtual Asset Asset { get; set; }
        public virtual Category Category { get; set; }
    }
}
