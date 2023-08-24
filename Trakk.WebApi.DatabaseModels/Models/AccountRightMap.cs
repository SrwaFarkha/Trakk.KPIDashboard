using System;
using Trakk.WebApi.Models;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class AccountRightMap : IEntity
    {
        public int AccountId { get; set; } // AccountId (Primary key)
        public Enums.AccountRight RightTypeId { get; set; } // RightTypeId (Primary key)
        public bool? IsActive { get; set; } // IsActive
        public DateTime? ValidUntil { get; set; } // ValidUntil
        public string? ValueData { get; set; } // ValueData

        // Foreign keys

        /// <summary>
        /// Parent Account pointed by [AccountRightMap].([AccountId]) (FK_AccountRightMap_Account)
        /// </summary>
        public virtual Account Account { get; set; } // FK_AccountRightMap_Account

        /// <summary>
        /// Parent RightType pointed by [AccountRightMap].([RightTypeId]) (FK_AccountRightTypeMap_RightType)
        /// </summary>
        public virtual RightType RightType { get; set; } // FK_AccountRightTypeMap_RightType

        public AccountRightMap()
        {
            IsActive = true;
        }
    }
}