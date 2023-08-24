

namespace Trakk.WebApi.DatabaseModels.Models
{
    public class Mapzone : IEntity
    {
        public int MapzoneId { get; set; } // MapzoneId (Primary key)
        public int CustomerId { get; set; } // CustomerId
        public string Name { get; set; } // Name (length: 50)
        public decimal Latitude { get; set; } // Latitude
        public decimal Longitude { get; set; } // Longitude
        public int ZoomLevel { get; set; } // ZoomLevel

        // Foreign keys

        /// <summary>
        /// Parent Customer pointed by [Mapzone].([CustomerId]) (FK_Mapzone_Customer)
        /// </summary>
        public virtual Customer Customer { get; set; } // FK_Mapzone_Customer
    }
}