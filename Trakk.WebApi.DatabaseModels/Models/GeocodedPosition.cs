using System;
using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public partial class GeocodedPosition : IEntity
    {
        public int GeocodedPositionId { get; set; } // GeocodedPositionId (Primary key)
        public string Street { get; set; } // Street (length: 255)
        public string HouseNumber { get; set; } // HouseNumber (length: 255)
        public string City { get; set; } // City (length: 255)
        public string PostalCode { get; set; } // PostalCode (length: 255)
        public string Country { get; set; } // Country (length: 3)
        public string Label { get; set; } // Label (length: 500)
        public DateTime CreatedOn { get; set; } // CreatedOn
        public decimal Latitude { get; set; } // Latitude
        public decimal Longitude { get; set; } // Longitude

        // Reverse navigation

        /// <summary>
        /// Child Positions where [Position].[GeocodedPositionId] point to this entity (FK_GeocodedPosition)
        /// </summary>
        public virtual ICollection<Position> Positions { get; set; } // Position.FK_GeocodedPosition

        public GeocodedPosition()
        {
            CreatedOn = DateTime.UtcNow;
            Positions = new List<Position>();
        }
    }
}