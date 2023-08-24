using System;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class Agreement : IEntity
    {
        public int AgreementId { get; set; } // AgreementId (Primary key)
        public string AgreementNumber { get; set; } // AgreementNumber (length: 256)
        public int UnitId { get; set; } // UnitId
        public DateTime? ValidTo { get; set; } // ValidTo
        public string? Comment { get; set; } // Comment
        public string? Reference { get; set; } // Reference
        public string? Finance { get; set; } // Finance
    }
}