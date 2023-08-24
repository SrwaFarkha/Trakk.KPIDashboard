using System.Collections.Generic;
using Trakk.WebApi.Models;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class RightType : IEntity
    {
        public Enums.AccountRight RightTypeId { get; set; } // RightTypeId (Primary key)
        public string Name { get; set; } // Name (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child AccountRightMaps where [AccountRightMap].[RightTypeId] point to this entity (FK_AccountRightTypeMap_RightType)
        /// </summary>
        public virtual ICollection<AccountRightMap> AccountRightMaps { get; set; } // AccountRightMap.FK_AccountRightTypeMap_RightType
        public List<CustomerFeature> CustomerFeatures { get; set; }

        public RightType()
        {
            AccountRightMaps = new List<AccountRightMap>();
            CustomerFeatures = new List<CustomerFeature>();
        }
    }
}