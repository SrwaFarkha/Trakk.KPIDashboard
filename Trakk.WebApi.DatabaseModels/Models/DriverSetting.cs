using System;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class DriverSetting : IEntity
    {
        public int AccountId { get; set; } // AccountId (Primary key)
        public TimeSpan? WorkStartMonday { get; set; } // WorkStartMonday
        public TimeSpan? WorkEndMonday { get; set; } // WorkEndMonday
        public TimeSpan? WorkStartTuesday { get; set; } // WorkStartTuesday
        public TimeSpan? WorkEndTuesday { get; set; } // WorkEndTuesday
        public TimeSpan? WorkStartWednesday { get; set; } // WorkStartWednesday
        public TimeSpan? WorkEndWednesday { get; set; } // WorkEndWednesday
        public TimeSpan? WorkStartThursday { get; set; } // WorkStartThursday
        public TimeSpan? WorkEndThursday { get; set; } // WorkEndThursday
        public TimeSpan? WorkStartFriday { get; set; } // WorkStartFriday
        public TimeSpan? WorkEndFriday { get; set; } // WorkEndFriday
        public TimeSpan? WorkStartSaturday { get; set; } // WorkStartSaturday
        public TimeSpan? WorkEndSaturday { get; set; } // WorkEndSaturday
        public TimeSpan? WorkStartSunday { get; set; } // WorkStartSunday
        public TimeSpan? WorkEndSunday { get; set; } // WorkEndSunday

        // Foreign keys

        /// <summary>
        /// Parent Account pointed by [DriverSettings].([AccountId]) (FK_DriverSettings_Account)
        /// </summary>
        public virtual Account Account { get; set; } // FK_DriverSettings_Account
    }
}