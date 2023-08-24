using System;
using System.Collections.Generic;
using Trakk.WebApi.Models;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class TrakkerEvent : IEntity
    {
        public int TrakkerEventId { get; set; } // TrakkerEventId (Primary key)
        public int TrakkerId { get; set; } // TrakkerId
        public DateTime OccuredOn { get; set; } // OccuredOn
        public Enums.TrakkerEventType TrakkerEventTypeId { get; set; } // TrakkerEventTypeId
        public Enums.AlertTypes? AlertTypeId { get; set; } // AlertTypeId
        public bool IsAgps { get; set; } // IsAGPS
        public int? PositionId { get; set; } // PositionId
        public decimal? Altitude { get; set; } // Altitude
        public decimal? Speed { get; set; } // Speed
        public decimal? Heading { get; set; } // Heading
        public byte? Accuracy { get; set; } // Accuracy
        public byte? BatteryLevel { get; set; } // BatteryLevel
        public int? Temperature { get; set; } // Temperature
        public string? Comment { get; set; } // Comment (length: 250)
        
        public virtual List<Extras> Extras { get; set; }

        // Reverse navigation

        /// <summary>
        /// Parent (One-to-One) TrakkerEvent pointed by [ActiveAlert].[TrakkerEventId] (FK_ActiveAlert_TrakkerEvent)
        /// </summary>
        public virtual ActiveAlert ActiveAlert { get; set; } // ActiveAlert.FK_ActiveAlert_TrakkerEvent

        /// <summary>
        /// Child Trakkers where [Trakker].[LatestEventId] point to this entity (FK_Trakker_LatestEventId)
        /// </summary>
        public virtual ICollection<Trakker> TrakkerLatestEvents { get; set; } // Trakker.FK_Trakker_LatestEventId

        /// <summary>
        /// Child Trakkers where [Trakker].[LatestPositionEventId] point to this entity (FK_Trakker_LatestPositionEventId)
        /// </summary>
        public virtual ICollection<Trakker> TrakkerLatestPositionEvents { get; set; } // Trakker.FK_Trakker_LatestPositionEventId

        /// <summary>
        /// Child Vehicles where [Vehicle].[LatestTrakkerEventId] point to this entity (FK_Vehicle_TrakkerEvent)
        /// </summary>
        public virtual ICollection<Vehicle> Vehicles { get; set; } // Vehicle.FK_Vehicle_TrakkerEvent

        // Foreign keys

        /// <summary>
        /// Parent Position pointed by [TrakkerEvent].([PositionId]) (FK_TrakkerEvent_Position)
        /// </summary>
        public virtual Position Position { get; set; } // FK_TrakkerEvent_Position

        /// <summary>
        /// Parent Trakker pointed by [TrakkerEvent].([TrakkerId]) (FK_TrakkerEvent_Trakker)
        /// </summary>
        public virtual Trakker Trakker { get; set; } // FK_TrakkerEvent_Trakker
        

        public TrakkerEvent()
        {
            OccuredOn = DateTime.UtcNow;
            TrakkerLatestEvents = new List<Trakker>();
            TrakkerLatestPositionEvents = new List<Trakker>();
            Vehicles = new List<Vehicle>();
            Extras = new List<Extras>();
        }
    }
}