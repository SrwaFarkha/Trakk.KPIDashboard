using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class Icon : IEntity
    {
        public int IconId { get; set; } // IconId (Primary key)
        public string Name { get; set; } // Name (length: 50)
        public string Url { get; set; } // Url

        // Reverse navigation

        /// <summary>
        /// Child HardwareConfigs where [HardwareConfig].[IconId] point to this entity (FK_HardwareConfig_Icon)
        /// </summary>
        public virtual ICollection<HardwareConfig> HardwareConfigs { get; set; } // HardwareConfig.FK_HardwareConfig_Icon

        /// <summary>
        /// Child Trakkers where [Trakker].[IconId] point to this entity (FK_Trakker_Icon)
        /// </summary>
        public virtual ICollection<Trakker> Trakkers { get; set; } // Trakker.FK_Trakker_Icon

        public Icon()
        {
            HardwareConfigs = new List<HardwareConfig>();
            Trakkers = new List<Trakker>();
        }
    }
}