using TestWebApp.Components.AdvertisingPlatforms.Api.InternalModels;

namespace TestWebApp.Components.AdvertisingPlatforms.Api;

public interface IRepository
{
     IReadOnlyList<PlatformLocalization> GetPlatformLocalizations();
     void AddPlatformLocalization(PlatformLocalization localization);
     void LoadData();
}