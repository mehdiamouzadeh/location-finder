using Locator.Features.IpLocation.Contracts;
using Locator.Features.IpLocation.Models;
using Microsoft.EntityFrameworkCore;

namespace Locator.Features.IpLocation
{
    public class LocationService(IEnumerable<ILocationProvider> providers,IpLocationDbContext dbContext)
    {
        private readonly IEnumerable<ILocationProvider> _providers = providers;
        private readonly IpLocationDbContext _dbContext = dbContext;

        public async Task<LocationResponse> GetLocationByIp(string Ip)
        {
            //Check data base
            var locatiion = await _dbContext.Locations.FirstOrDefaultAsync(d => d.IP == Ip);
            if (locatiion is not null)
            {
                return new LocationResponse(locatiion.Country,locatiion.State, locatiion.City);
            }   
            foreach (var provider in _providers)
            {
                var locationResponse = await provider.GetLocation(Ip);
                if (!locationResponse.IsSuccessful)
                    continue;
                var newLocation = new Location
                {
                    City = locationResponse.City,
                    Country = locationResponse.Country,
                    State = locationResponse.State,
                    IP = Ip,
                    Latitude = locationResponse.Latitude,
                    Longitude = locationResponse.Longitude
                };
                //persist
                _dbContext.Locations.Add(newLocation);
                await _dbContext.SaveChangesAsync();
                //return new location
                return new LocationResponse(newLocation.Country, newLocation.State, newLocation.City);
            }
            throw new InvalidProviderResultException(Ip);
        }
    }
}
