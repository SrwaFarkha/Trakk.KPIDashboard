using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trakk.WebApi.DatabaseModels.Models.VehicleEvent_V2;

namespace Trakk.WebApi.DatabaseModels.Models
{
    public class IsaEvent
    {
        public int Id { get; set; }
        public int VehicleEventId { get; set; }
        public double SpeedLimit { get; set; }
        public double MaxSpeed { get; set; }
        public ICollection<EventPosition> EventPositions { get; set; }
        //public int FromEventPositionId { get; set; }
        //public int? ToEventPositionId { get; set; }
        [NotMapped] public EventPosition FromEventPosition => EventPositions.OrderBy(x => x.TimeStamp).First();
        [NotMapped] public EventPosition? ToEventPosition => EventPositions.OrderBy(x => x.TimeStamp).Last();
        public virtual VehicleEvent_V2.VehicleEvent VehicleEvent { get; set; }
    }
}
