using Locator.Features.IpLocation.Contracts;

namespace Locator.Features.IpLocation;

public interface ILocationProvider
{
    public Task<LocationProviderResult> GetLocation(string Ip);
}
