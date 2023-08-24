

namespace Trakk.WebApi.DatabaseModels.Models
{
    public class DbSetting : IEntity
    {
        public int Id { get; set; } // Id (Primary key)
        public bool IsIntegrationTestDb { get; set; } // IsIntegrationTestDB
    }
}