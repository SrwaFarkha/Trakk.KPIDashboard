using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; } // CategoryId (Primary key)
        public int CustomerId { get; set; } // CustomerId
        public int CategoryTypeId { get; set; } // CategoryTypeId
        public string Name { get; set; } // Name (length: 255)

        // Reverse navigation

        /// <summary>
        /// Child Assets (Many-to-Many) mapped by table [CategoryAssetMap]
        /// </summary>
        public virtual ICollection<Asset> Assets { get; set; } // Many to many mapping

        /// <summary>
        /// Child Trakkers (Many-to-Many) mapped by table [CategoryTrakkerMap]
        /// </summary>
        public virtual ICollection<Trakker> Trakkers { get; set; } // Many to many mapping

        /// <summary>
        /// Child Vehicles (Many-to-Many) mapped by table [CategoryVehicleMap]
        /// </summary>
        public virtual ICollection<Vehicle> Vehicles { get; set; } // Many to many mapping

        // Foreign keys

        /// <summary>
        /// Parent CategoryType pointed by [Category].([CategoryTypeId]) (FK_CategoryType)
        /// </summary>
        public virtual CategoryType CategoryType { get; set; } // FK_CategoryType

        public Category()
        {
            Assets = new List<Asset>();
            Trakkers = new List<Trakker>();
            Vehicles = new List<Vehicle>();
        }
    }
}