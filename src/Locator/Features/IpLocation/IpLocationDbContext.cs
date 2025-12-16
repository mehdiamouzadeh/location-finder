using Locator.Features.IpLocation.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Locator.Features.IpLocation
{
    public class IpLocationDbContext(DbContextOptions<IpLocationDbContext> dbContextOptions) : DbContext(dbContextOptions)
    {

        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Location>().ToCollection("locations");
        }
    }


}
