using System.ComponentModel.DataAnnotations;

namespace TestWebApp.Components.AdvertisingPlatforms.Api.InternalModels;

public class PlatformLocalization
{
    [Key]
    public string PlatformName;

    public string[] AvailableLocations;

    public PlatformLocalization(string platformName, string[] availableLocations)
    {
        PlatformName = platformName;
        AvailableLocations = availableLocations;
    }
}