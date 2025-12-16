
using Locator.Features.IpLocation.Contracts;
using Locator.Features.IpLocation.Providers.IpGeoLocation;
using Microsoft.Extensions.Options;
using System.Net.Http;

namespace Locator.Features.IpLocation.Providers.IpApi
{
    public class IpApiLocationProvider(
        IHttpClientFactory httpClientFactory
        ) : ILocationProvider
    {
        private readonly IHttpClientFactory _clientFactory = httpClientFactory;
        private const string BaseUrl = "http://ip-api.com/json/";
        public async Task<LocationProviderResult> GetLocation(string Ip)
        {
            var httpClient = _clientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(BaseUrl);
            var response = await httpClient.GetFromJsonAsync<IpApiResponse>($"{Ip}");
            if (response is null)
                return LocationProviderResult.Failed();
            return new LocationProviderResult()
            {
                IsSuccessful = true,
                City = response.City,
                Country = response.Country,
                Latitude = response.Latitude,
                Longitude = response.Longitude,
                State = response.RegionName
            };
        }
    }
}
