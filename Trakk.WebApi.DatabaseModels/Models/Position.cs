using System;
using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public partial class Position : IEntity
    {
        public int PositionId { get; set; } // PositionId (Primary key)
        public decimal Latitude { get; set; } // Latitude
        public decimal Longitude { get; set; } // Longitude
        public int? GeocodedPositionId { get; set; } // GeocodedPositionId
        public DateTime CreatedOn { get; set; } // CreatedOn

        // Reverse navigation

        /// <summary>
        /// Child AssetEvents where [AssetEvent].[PositionId] point to this entity (FK_AssetEvent_Position)
        /// </summary>
        public virtual ICollection<AssetEvent> AssetEvents { get; set; } // AssetEvent.FK_AssetEvent_Position

        /// <summary>
        /// Child BaseStations where [BaseStation].[PositionId] point to this entity (FK_BaseStation_Position)
        /// </summary>
        public virtual ICollection<BaseStation> BaseStations { get; set; } // BaseStation.FK_BaseStation_Position

        /// <summary>
        /// Child TrakkerEvents where [TrakkerEvent].[PositionId] point to this entity (FK_TrakkerEvent_Position)
        /// </summary>
        public virtual ICollection<TrakkerEvent> TrakkerEvents { get; set; } // TrakkerEvent.FK_TrakkerEvent_Position

        /// <summary>
        /// Child VehicleEvents where [VehicleEvent].[FromPositionId] point to this entity (FK_VehicleEvent_FromPosition)
        /// </summary>
        //public virtual ICollection<VehicleEvent> VehicleEvents_FromPositionId { get; set; } // VehicleEvent.FK_VehicleEvent_FromPosition

        /// <summary>
        /// Child VehicleEvents where [VehicleEvent].[ToPositionId] point to this entity (FK_VehicleEvent_ToPosition)
        /// </summary>
     //   public virtual ICollection<VehicleEvent> VehicleEvents_ToPositionId { get; set; } // VehicleEvent.FK_VehicleEvent_ToPosition

        /// <summary>
        /// Child VehicleEventPositionMaps where [VehicleEventPositionMap].[PositionId] point to this entity (FK_VehicleEventPositionMap_PositionId)
        /// </summary>
       // public virtual ICollection<VehicleEventPositionMap> VehicleEventPositionMaps { get; set; } // VehicleEventPositionMap.FK_VehicleEventPositionMap_PositionId

        // Foreign keys

        /// <summary>
        /// Parent GeocodedPosition pointed by [Position].([GeocodedPositionId]) (FK_GeocodedPosition)
        /// </summary>
        public virtual GeocodedPosition GeocodedPosition { get; set; } // FK_GeocodedPosition

        public Position()
        {
            CreatedOn = DateTime.UtcNow;
            AssetEvents = new List<AssetEvent>();
            BaseStations = new List<BaseStation>();
            TrakkerEvents = new List<TrakkerEvent>();
          //  VehicleEvents_FromPositionId = new List<VehicleEvent>();
          //  VehicleEvents_ToPositionId = new List<VehicleEvent>();
          //  VehicleEventPositionMaps = new List<VehicleEventPositionMap>();
        }
    }
}