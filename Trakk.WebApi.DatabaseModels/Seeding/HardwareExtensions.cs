using Trakk.WebApi.Models;

namespace Trakk.WebApi.DatabaseModels.Seeding;

public static class HardwareExtensions
{
    public static bool GotSimSlot(this Enums.HardwareType type) =>
        type switch
        {
            Enums.HardwareType.GL200 => true,
            Enums.HardwareType.GL300 => true,
            Enums.HardwareType.GL300A => true,
            Enums.HardwareType.GMT100 => true,
            Enums.HardwareType.GMT200 => true,
            Enums.HardwareType.GV500 => true,
            Enums.HardwareType.OB022 => true,
            Enums.HardwareType.GL500M => true,
            Enums.HardwareType.HVT001 => true,
            Enums.HardwareType.AT1 => true,
            Enums.HardwareType.GT08 => true,
            Enums.HardwareType.AT4 => true,
            Enums.HardwareType.JM01 => true,
            Enums.HardwareType.VL103 => true,
            Enums.HardwareType.LL303 => true,
            _ => false
        };
}