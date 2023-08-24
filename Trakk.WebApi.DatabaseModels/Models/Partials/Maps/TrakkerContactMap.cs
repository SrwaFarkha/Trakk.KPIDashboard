#nullable disable

using Microsoft.EntityFrameworkCore;

namespace Trakk.WebApi.DatabaseModels.Models.Partials
{

    public partial class TrakkerContactMap
    {
        public int TrakkerId { get; set; }
        public int ContactId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Trakker Trakker { get; set; }
    }
}
