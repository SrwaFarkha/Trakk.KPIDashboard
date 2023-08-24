using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class HardwareStatus : IEntity
    {
        public int HardwareStatusId { get; set; } // HardwareStatusId (Primary key)
        public string Name { get; set; } // Name (length: 100)

        // Reverse navigation

        /// <summary>
        /// Child Hardwares where [Hardware].[HardwareStatusId] point to this entity (FK_Hardware_HardwareStatus)
        /// </summary>
        public virtual ICollection<Hardware> Hardwares { get; set; } // Hardware.FK_Hardware_HardwareStatus

        public HardwareStatus()
        {
            Hardwares = new List<Hardware>();
        }
    }
}