using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Trakk.WebApi.DatabaseModels.Models
{
    public partial class Vehicle
    {
        [NotMapped] public List<Models.Geofence> ParkingGeofences { get; set; } = new List<Models.Geofence>();

        public void SetGeofences()
        {
            ParkingGeofences = Trakkers.SelectMany(x => x.Geofences).Where(x => x.GeofenceTypeId == 4).ToList();
        }

        //     public void AddPosition(VehiclePosition position, double timeoutSeconds = 180, int thresholdMeters = 150)
        //     {
        //         VehiclePositions.Add(position);
        //         UpdateTrips(position, timeoutSeconds, thresholdMeters);
        //         
        //     }
        //
        //     public void UpdateTrips(VehiclePosition vehiclePosition, double timeoutSeconds = 180, int thresholdMeters = 150 )
        //     {
        //         var ev = TripEvents.FirstOrDefault(x => x.IsWithinMargin(TimeSpan.FromMinutes(3), vehiclePosition.CreatedDate));
        //         if (ev == null)
        //         { 
        //             ev = new TripEvent
        //             {
        //                 VehicleId = this.VehicleId,
        //                 Timeout = TimeSpan.FromSeconds(timeoutSeconds),
        //                 Positions = new LinkedList<VehiclePosition> {  }
        //             };
        //             var selectedTrip = TripEvents.Last;
        //             if (selectedTrip == null)
        //             {
        //                 selectedTrip = TripEvents.AddLast(ev);
        //             }
        //             //reverse check
        //             else
        //             {
        //                 while (selectedTrip != null)
        //                 {
        //                     if ((vehiclePosition.CreatedDate > selectedTrip.Value.StartTime))
        //                     {
        //                         ev = TripEvents.AddAfter(selectedTrip, ev).ValueRef;
        //                         break;
        //                     }
        //                     selectedTrip = selectedTrip.Previous;
        //                 }
        //                 
        //             }
        //         }
        //         ev.InsertPosition(vehiclePosition, thresholdMeters);
        //         CheckOverLap(ev);
        //     }
        //
        //     public void RemoveOnePositionTrips()
        //     {
        //         var tevents = TripEvents.Where(x => x.Positions.Count == 1 && !x.IsActive).ToList();
        //         foreach (var VARIABLE in tevents)
        //         {
        //             TripEvents.Remove(VARIABLE);
        //         }
        //     }
        //
        //     public void CheckOverLap(TripEvent ev)
        //     {
        //         var trip = TripEvents.Find(ev);
        //         var next = trip?.Next;
        //         
        //         if (next != null && trip.Value.CheckOverlap(next.Value))
        //         {
        //             var positions = next.Value.Positions;
        //             foreach (var pos in positions)
        //             {
        //                 trip.Value.InsertPosition(pos);
        //             }
        //
        //             TripEvents.Remove(next);
        //         }
        //     }
    }
}
