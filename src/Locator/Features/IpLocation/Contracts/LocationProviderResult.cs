namespace Locator.Features.IpLocation.Contracts;

public class LocationProviderResult
{
    public bool IsSuccessful { get; set; }
    public string City { get; internal set; }
    public string Country { get; internal set; }
    public string State { get; internal set; }
    public double Latitude { get; internal set; }
    public double Longitude { get; internal set; }

    public static LocationProviderResult Failed() => new LocationProviderResult { IsSuccessful = false };
}
