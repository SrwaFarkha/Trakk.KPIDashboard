using System;

#nullable disable

namespace Trakk.WebApi.DatabaseModels.Models.Partials
{
    public partial class VehicleEventPositionMap
    {
        public int Id { get; set; }
        public int VehicleEventId { get; set; }
        public int PositionId { get; set; }
        public DateTime OccuredOn { get; set; }

        public virtual Position Position { get; set; }
        //public virtual VehicleEvent VehicleEvent { get; set; }
    }
}
