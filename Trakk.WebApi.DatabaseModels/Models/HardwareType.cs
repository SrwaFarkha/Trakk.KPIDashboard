using System.Collections.Generic;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class HardwareType : IEntity
    {
        public int HardwareTypeId { get; set; } // HardwareTypeId (Primary key)
        public string Name { get; set; } // Name (length: 50)
        public string Url { get; set; } // Url (length: 250)
        public bool HasSimCardSlot { get; set; } // HasSimCardSlot
        public bool HasExternalBattery { get; set; }

        // Reverse navigation

        /// <summary>
        /// Child Hardwares where [Hardware].[HardwareTypeId] point to this entity (FK_Hardware_HardwareType)
        /// </summary>
        public virtual ICollection<Hardware> Hardwares { get; set; } // Hardware.FK_Hardware_HardwareType

        /// <summary>
        /// Child SmsCommands where [SmsCommand].[HardwareTypeId] point to this entity (FK_SmsCommand_HardwareType)
        /// </summary>
        public virtual ICollection<SmsCommand> SmsCommands { get; set; } // SmsCommand.FK_SmsCommand_HardwareType

        public HardwareType()
        {
            HasExternalBattery = false;
            HasSimCardSlot = true;
            Hardwares = new List<Hardware>();
            SmsCommands = new List<SmsCommand>();
        }
    }
}