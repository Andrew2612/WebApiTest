using TestWebApp.Components.AdvertisingPlatforms.Api.ExternalModels;

namespace TestWebApp.Components.AdvertisingPlatforms.Api;

public interface IController
{
    public IReadOnlyList<PlatformLocalization> GetPlatformLocalizations();
    public IReadOnlyList<string> GetAvailablePlatforms(string location);
    public void AddPlatformLocalization(string platformName, string[] availableLocations);
    public void LoadData();
}