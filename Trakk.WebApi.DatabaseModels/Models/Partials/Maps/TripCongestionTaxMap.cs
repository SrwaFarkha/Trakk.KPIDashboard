#nullable disable

namespace Trakk.WebApi.DatabaseModels.Models.Partials
{
    public partial class TripCongestionTaxMap
    {
        public int TripVehicleEventId { get; set; }
        public int CongestionTaxVehicleEventId { get; set; }
        //
        // public virtual VehicleEvent CongestionTaxVehicleEvent { get; set; }
        // public virtual VehicleEvent TripVehicleEvent { get; set; }
    }
}
