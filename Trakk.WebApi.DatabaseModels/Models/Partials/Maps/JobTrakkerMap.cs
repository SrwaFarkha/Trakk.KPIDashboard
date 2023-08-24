#nullable disable

namespace Trakk.WebApi.DatabaseModels.Models.Partials
{
    public partial class JobTrakkerMap
    {
        public int JobId { get; set; }
        public int TrakkerId { get; set; }

        public virtual Job Job { get; set; }
        public virtual Trakker Trakker { get; set; }
    }
}
