namespace Trakk.Configuration.Models;

public enum GeocodeProviderType
{
    Mapquest,
    HereApi,
    Nominatim
}
public class GeocoderOptions
{
    public GeocodeProviderType GeocodeProvider { get; set; } = GeocodeProviderType.HereApi;
    public string NominatimBaseUrl { get; set; } = "";
    public string HereApiKey { get; set; } = "";
    public string MapquestApiKey { get; set; } = "";
}