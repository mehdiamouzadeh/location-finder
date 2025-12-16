
using Locator.Features.IpLocation.Contracts;
using Microsoft.Extensions.Options;

namespace Locator.Features.IpLocation.Providers.IpGeoLocation
{
    public class IpGeoLocationProvider(
        IHttpClientFactory httpClientFactory,
        IOptions<AppSettings> options) : ILocationProvider
    {
        private readonly string ApiKey = options.Value.Features.IpLocation.Providers.IpGeoLocation;
        private readonly IHttpClientFactory _clientFactory = httpClientFactory;
        private const string BaseUrl = "https://api.ipgeolocation.io/v2/ipgeo";
        public async Task<LocationProviderResult> GetLocation(string Ip)
        {
            var httpClient = _clientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(BaseUrl);
            var response = await httpClient.GetFromJsonAsync<IpGeoResponse>($"?apiKey={ApiKey}&ip={Ip}");
            if (response is null)
                return LocationProviderResult.Failed();
            return new LocationProviderResult()
            {
                IsSuccessful = true,
                City = response.location.City,
                Country = response.location.CountryName,
                Latitude = response.location.Latitude,
                Longitude = response.location.Longitude,
                State = response.location.StateProv
            };
        }
    }
}
