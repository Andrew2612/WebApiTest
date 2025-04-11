using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApp.Components.AdvertisingPlatforms.Api.InternalModels;

namespace TestWebApp.Components.AdvertisingPlatforms.Implementation.Configurations
{
    public class Configuration : IEntityTypeConfiguration<PlatformLocalization>
    {
        public void Configure(EntityTypeBuilder<PlatformLocalization> builder)
        {
            builder.Property(x => x.PlatformName).IsRequired();
            builder.Property(x => x.PlatformName).HasMaxLength(50);

            builder.Property(x => x.AvailableLocations).IsRequired(); 
        }
    }
}
