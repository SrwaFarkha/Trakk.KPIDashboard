#nullable disable


namespace Trakk.WebApi.DatabaseModels.Models.Partials
{
    public partial class AccountGroupMap
    {
        public int AccountId { get; set; }
        public int GroupId { get; set; }
        public bool Access { get; set; }
        public bool IsFavorite { get; set; }

        public virtual Account Account { get; set; }
        public virtual Group Group { get; set; }
    }
}
