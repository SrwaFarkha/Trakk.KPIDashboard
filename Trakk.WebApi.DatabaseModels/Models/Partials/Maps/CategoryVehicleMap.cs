#nullable disable

namespace Trakk.WebApi.DatabaseModels.Models.Partials
{
    public partial class CategoryVehicleMap
    {
        public int CategoryId { get; set; }
        public int VehicleId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
