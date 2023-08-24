using System;

#nullable disable

namespace Trakk.WebApi.DatabaseModels.Models.Partials
{
    public partial class CustomerServiceMap
    {
        public int CustomerId { get; set; }
        public int ServiceId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? ValidUntil { get; set; }
        public string ValueData { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Service Service { get; set; }
    }
}
