using TestWebApp.Components.AdvertisingPlatforms.Api;
using TestWebApp.Components.AdvertisingPlatforms.Api.InternalModels;

namespace Components.AdvertisingPlatforms.Implementation;

public class PlatformLocalizationSetter
{
    readonly IRepository repository;

    public PlatformLocalizationSetter(IRepository repository)
    {
        this.repository = repository;
    }

    public void AddPlatformLocalization(string platformName, string[] availableLocations)
    {
        if (string.IsNullOrEmpty(platformName))
        {
            throw new AddPlatformWithNoNameExc();
        }

        if (availableLocations.Length == 0)
        {
            throw new AddPlatformWithNoLocationDefinedExc(platformName);
        }

        if (repository.GetPlatformLocalizations().Any(x => x.PlatformName == platformName))
        {
            throw new PlatformLocalizationAlreadyDefinedExc(platformName);
        }

        repository.AddPlatformLocalization(new PlatformLocalization(platformName, availableLocations));
    }

    public void LoadData()
    {
        repository.LoadData();
    }
}