using Microsoft.EntityFrameworkCore;
using TestWebApp.Components.AdvertisingPlatforms.Api.InternalModels;

namespace TestWebApp.Components.AdvertisingPlatforms.Api
{
    public interface IDbContext
    {
        DbSet<PlatformLocalization> PlatformLocalizations { get; }
    }
}
