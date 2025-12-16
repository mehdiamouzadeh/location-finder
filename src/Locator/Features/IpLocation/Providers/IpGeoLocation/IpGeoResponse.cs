using System.Text.Json.Serialization;

namespace Locator.Features.IpLocation.Providers.IpGeoLocation
{
    public class Location
    {
        [JsonPropertyName("country_name")]
        public required string CountryName { get; set; }
        [JsonPropertyName("state_prov")]
        public required string StateProv { get; set; }
        [JsonPropertyName("city")]
        public required string City { get; set; }
        [JsonPropertyName("latitude")]
        public required double Latitude { get; set; }
        [JsonPropertyName("longitude")]
        public required double Longitude { get; set; }
    }

    public class IpGeoResponse
    {
        public Location location { get; set; }
    }
}
