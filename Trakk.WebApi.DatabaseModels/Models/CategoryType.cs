using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class CategoryType : IEntity
    {
        public int CategoryTypeId { get; set; } // CategoryTypeId (Primary key)
        public int? CustomerId { get; set; } // CustomerId
        public string Name { get; set; } // Name (length: 255)

        // Reverse navigation

        /// <summary>
        /// Child Categories where [Category].[CategoryTypeId] point to this entity (FK_CategoryType)
        /// </summary>
        public virtual ICollection<Category> Categories { get; set; } // Category.FK_CategoryType

        public CategoryType()
        {
            Categories = new List<Category>();
        }
    }
}