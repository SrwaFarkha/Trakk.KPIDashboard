

namespace Trakk.WebApi.DatabaseModels.Models
{
    public class SmsOperator : IEntity
    {
        public int SmsOperatorId { get; set; } // SmsOperatorId (Primary key)
        public string Name { get; set; } // Name (length: 100)
        public string Apn { get; set; } // Apn (length: 256)
        public string User { get; set; } // User (length: 100)
        public string Password { get; set; } // Password (length: 100)
    }
}