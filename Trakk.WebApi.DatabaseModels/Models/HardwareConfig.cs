using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class HardwareConfig : IEntity
    {
        public int HardwareConfigId { get; set; } // HardwareConfigId (Primary key)
        public string Name { get; set; } // Name (length: 255)
        public int IconId { get; set; } // IconId
        public int? VibrationSensitivity { get; set; } // VibrationSensitivity
        public int? SecondsStillUntilStop { get; set; } // SecondsStillUntilStop

        // Reverse navigation

        /// <summary>
        /// Child Hardwares where [Hardware].[HardwareConfigId] point to this entity (FK_Hardware_HardwareConfig)
        /// </summary>
        public virtual ICollection<Hardware> Hardwares { get; set; } // Hardware.FK_Hardware_HardwareConfig

        // Foreign keys

        /// <summary>
        /// Parent Icon pointed by [HardwareConfig].([IconId]) (FK_HardwareConfig_Icon)
        /// </summary>
        public virtual Icon Icon { get; set; } // FK_HardwareConfig_Icon

        public HardwareConfig()
        {
            Hardwares = new List<Hardware>();
        }
    }
}