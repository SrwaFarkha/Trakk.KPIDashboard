#nullable disable

namespace Trakk.WebApi.DatabaseModels.Models.Partials
{
    public partial class TrakkerGroupMap
    {
        public int TrakkerId { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Trakker Trakker { get; set; }
    }
}
