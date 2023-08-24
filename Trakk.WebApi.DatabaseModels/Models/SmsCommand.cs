

namespace Trakk.WebApi.DatabaseModels.Models
{
    public class SmsCommand : IEntity
    {
        public int SmsCommandId { get; set; } // SmsCommandId (Primary key)
        public string Name { get; set; } // Name (length: 100)
        public string Description { get; set; } // Description (length: 100)
        public string Command { get; set; } // Command
        public int HardwareTypeId { get; set; } // HardwareTypeId

        // Foreign keys

        /// <summary>
        /// Parent HardwareType pointed by [SmsCommand].([HardwareTypeId]) (FK_SmsCommand_HardwareType)
        /// </summary>
        public virtual HardwareType HardwareType { get; set; } // FK_SmsCommand_HardwareType
    }
}