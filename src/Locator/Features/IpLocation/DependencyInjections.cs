using Locator.Features.IpLocation.Providers.IpApi;
using Locator.Features.IpLocation.Providers.IpGeoLocation;
using Microsoft.EntityFrameworkCore;

namespace Locator.Features.IpLocation;

public static class DependencyInjections
{

    public static void AddIpLocationFeature(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ILocationProvider, IpGeoLocationProvider>();
        builder.Services.AddScoped<ILocationProvider, IpApiLocationProvider>();
        builder.Services.AddScoped<LocationService>();
        var settings = builder.Configuration.Get<AppSettings>();
        builder.Services.AddDbContext<IpLocationDbContext>(configure =>
        {   
            _ = settings ??  throw new ArgumentNullException(nameof(settings));
            
            configure.UseMongoDB(settings.MongoDbSettings.Host, settings.MongoDbSettings.DatabaseName);
        });
    }

}
