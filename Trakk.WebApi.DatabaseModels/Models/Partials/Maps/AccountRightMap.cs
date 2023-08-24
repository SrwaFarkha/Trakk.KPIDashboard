using System;

#nullable disable

namespace Trakk.WebApi.DatabaseModels.Models.Partials
{
    public partial class AccountRightMap
    {
        public int AccountId { get; set; }
        public int RightTypeId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? ValidUntil { get; set; }
        public string ValueData { get; set; }

        public virtual Account Account { get; set; }
        public virtual RightType RightType { get; set; }
    }
}
