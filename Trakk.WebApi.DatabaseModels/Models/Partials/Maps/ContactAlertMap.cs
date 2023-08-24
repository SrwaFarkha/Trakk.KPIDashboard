#nullable disable

namespace Trakk.WebApi.DatabaseModels.Models.Partials
{
    public partial class ContactAlertMap
    {
        public int ContactId { get; set; }
        public int AlertId { get; set; }

        public virtual AlertType Alert { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
