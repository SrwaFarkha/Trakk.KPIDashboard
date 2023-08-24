using System;
using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class Asset : IEntity
    {
        public int AssetId { get; set; } // AssetId (Primary key)
        public int TrakkerId { get; set; } // TrakkerId
        public int SecondsStillUntilStop { get; set; } // SecondsStillUntilStop
        public int OperationTimeCounter { get; set; } // OperationTimeCounter
        public double? Co2ByMin { get; set; } // OperationTimeCounter
        public int? LatestAssetEventId { get; set; } // LatestAssetEventId
        public DateTime CreatedOn { get; set; } // CreatedOn

        // Reverse navigation

        /// <summary>
        /// Child AssetEvents where [AssetEvent].[AssetId] point to this entity (FK_AssetEvent_Asset)
        /// </summary>
        public virtual ICollection<AssetEvent> AssetEvents { get; set; } // AssetEvent.FK_AssetEvent_Asset

        /// <summary>
        /// Child Categories (Many-to-Many) mapped by table [CategoryAssetMap]
        /// </summary>
        public virtual ICollection<Category> Categories { get; set; } // Many to many mapping

        /// <summary>
        /// Child Jobs (Many-to-Many) mapped by table [JobAssetMap]
        /// </summary>
        public virtual ICollection<Job> Jobs { get; set; } // Many to many mapping

        // Foreign keys

        /// <summary>
        /// Parent AssetEvent pointed by [Asset].([LatestAssetEventId]) (FK_Asset_LatestAssetEvent)
        /// </summary>
        public virtual AssetEvent? LatestAssetEvent { get; set; } // FK_Asset_LatestAssetEvent

        /// <summary>
        /// Parent Trakker pointed by [Asset].([TrakkerId]) (FK_Asset_Trakker)
        /// </summary>
        public virtual Trakker Trakker { get; set; } // FK_Asset_Trakker

        public Asset()
        {
            OperationTimeCounter = 0;
            Co2ByMin = 0;
            CreatedOn = DateTime.UtcNow;
            AssetEvents = new List<AssetEvent>();
            Categories = new List<Category>();
            Jobs = new List<Job>();
        }
    }
}