#nullable disable

namespace Trakk.WebApi.DatabaseModels.Models.Partials
{
    public partial class TrakkerVehicleMap
    {
        public int TrakkerId { get; set; }
        public int VehicleId { get; set; }

        public virtual Trakker Trakker { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
