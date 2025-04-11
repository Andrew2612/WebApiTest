using TestWebApp.Components.AdvertisingPlatforms.Api;
using ExternalModels = TestWebApp.Components.AdvertisingPlatforms.Api.ExternalModels;
using InternalModels = TestWebApp.Components.AdvertisingPlatforms.Api.InternalModels;

namespace Components.AdvertisingPlatforms.Implementation;

public class PlatformLocalizationGetter
{
    readonly IRepository repository;

    public PlatformLocalizationGetter(IRepository repository)
    {
        this.repository = repository;
    }

    public IReadOnlyList<ExternalModels.PlatformLocalization> GetPlatformLocalizations()
    {
        IReadOnlyList<InternalModels.PlatformLocalization> platformLocalizations = repository.GetPlatformLocalizations();

        var externalPlatformLocalizations = new List<ExternalModels.PlatformLocalization>();
        
        foreach (InternalModels.PlatformLocalization platformLocalization in platformLocalizations)
        {
            externalPlatformLocalizations.Add(new ExternalModels.PlatformLocalization
            {
                PlatformName = platformLocalization.PlatformName,
                AvailableLocations = platformLocalization.AvailableLocations
            });
        }

        return externalPlatformLocalizations;
    }

    public IReadOnlyList<string> GetAvailablePlatforms(string location)
    {
        if (string.IsNullOrEmpty(location))
        {
            throw new SearchPlatformWithNoLocationDefinedExc();
        }

        string[] parts = location.Split(new[] { "%2F" }, StringSplitOptions.None);

        return repository.GetPlatformLocalizations()
            .Where(x => CheckIfLocalizationAvailable(parts, x.AvailableLocations))
            .Select(x => x.PlatformName).ToList();
    }

    bool CheckIfLocalizationAvailable(string[] parts, string[] availableLocations)
    {
        foreach (string part in parts)
        {
            if (string.IsNullOrEmpty(part))
            {
                continue;
            }

            foreach (string availableLocation in availableLocations)
            {
                if (availableLocation.EndsWith(part))
                {
                    return true;
                }
            }
        }

        return false;
    }
}