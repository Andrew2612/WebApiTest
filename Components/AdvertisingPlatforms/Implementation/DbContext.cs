using Microsoft.EntityFrameworkCore;
using TestWebApp.Components.AdvertisingPlatforms.Api.InternalModels;
using TestWebApp.Components.AdvertisingPlatforms.Api;
using TestWebApp.Components.AdvertisingPlatforms.Implementation.Configurations;

namespace TestWebApp.Components.AdvertisingPlatforms.Implementation
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext, IDbContext
    {
        public DbContext(DbContextOptions<DbContext> options)
            : base(options) { }

        public DbSet<PlatformLocalization> PlatformLocalizations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Configuration).Assembly);
        }
    }
}
