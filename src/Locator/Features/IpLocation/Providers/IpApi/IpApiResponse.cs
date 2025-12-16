using System.Text.Json.Serialization;

namespace Locator.Features.IpLocation.Providers.IpApi;

public class IpApiResponse
{
    [JsonPropertyName("country")]
    public required string Country { get; set; }
    public required string region { get; set; }
    [JsonPropertyName("regionName")]
    public required string RegionName { get; set; }
    [JsonPropertyName("city")]
    public required string City { get; set; }
   
    [JsonPropertyName("lat")]
    public required double Latitude { get; set; }
    [JsonPropertyName("lon")]
    public required double Longitude { get; set; }

}

