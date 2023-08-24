namespace Trakk.WebApi.DatabaseModels.Models
{
    public partial class GeocodedPosition
    {
        public override string ToString()
        {
            if (string.IsNullOrEmpty(HouseNumber))
            {
                return $"{Street}, {City}, {Country}";
            }

            return $"{Street}, {HouseNumber}, {City}, {Country}";
        }

        public string ToLabel()
        {
            return !string.IsNullOrEmpty(Label) ? Label : !string.IsNullOrEmpty(ToString())? ToString() : "ingen resa";
        }
    }
}
