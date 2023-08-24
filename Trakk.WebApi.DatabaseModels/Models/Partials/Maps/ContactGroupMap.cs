#nullable disable

namespace Trakk.WebApi.DatabaseModels.Models.Partials
{
    public partial class ContactGroupMap
    {
        public int ContactId { get; set; }
        public int GroupId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Group Group { get; set; }
    }
}
