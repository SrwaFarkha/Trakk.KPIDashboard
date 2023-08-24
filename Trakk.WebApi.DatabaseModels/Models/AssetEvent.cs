using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Trakk.WebApi.Models;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class AssetEvent : IEntity
    {
        public int AssetEventId { get; set; } // AssetEventId (Primary key)
        public int AssetId { get; set; } // AssetId
        public Enums.AssetEventType AssetEventTypeId { get; set; } // AssetEventTypeId
        public int? PositionId { get; set; } // PositionId
        public DateTime? PositionOn { get; set; }
        public DateTime StartDateTime { get; set; } // StartDateTime
        public DateTime? StopDateTime { get; set; } // StopDateTime
        public string GeofenceName { get; set; } // GeofenceName (length: 255)
        public string Comment { get; set; } // Comment (length: 255)
        public TimeSpan PrivateOperationTime { get; set; }
        public TimeSpan WorkOperationTime { get; set; }
        [NotMapped] public TimeSpan Duration => (StopDateTime ?? DateTime.UtcNow) - StartDateTime;

        // Reverse navigation

        /// <summary>
        /// Child Assets where [Asset].[LatestAssetEventId] point to this entity (FK_Asset_LatestAssetEvent)
        /// </summary>
        public virtual ICollection<Asset> Assets { get; set; } // Asset.FK_Asset_LatestAssetEvent

        // Foreign keys

        /// <summary>
        /// Parent Asset pointed by [AssetEvent].([AssetId]) (FK_AssetEvent_Asset)
        /// </summary>
        public virtual Asset Asset { get; set; } // FK_AssetEvent_Asset

        /// <summary>
        /// Parent Position pointed by [AssetEvent].([PositionId]) (FK_AssetEvent_Position)
        /// </summary>
        public virtual Position Position { get; set; } // FK_AssetEvent_Position

        public AssetEvent()
        {
            Assets = new List<Asset>();
        }
    }
}