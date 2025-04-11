using TestWebApp.Components.AdvertisingPlatforms.Api.InternalModels;

namespace TestWebApp.Components.AdvertisingPlatforms.Implementation;

public class ControllerTests
{
    const string Filename = "Components\\AdvertisingPlatforms\\Implementation\\Configurations\\AdvertisingPlatforms.txt";

    public List<PlatformLocalization> Load()
    {
        var platformLocalizations = new List<PlatformLocalization>();

        using (StreamReader reader = new StreamReader(Filename))
        {
            string? line;
            
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(':');

                if (parts.Length < 2)
                {
                    throw new Exception();
                }

                string[] availableLocations = parts[1].Trim().Split(",");

                if (availableLocations.Length < 1)
                {
                    throw new Exception();
                }

                platformLocalizations.Add(new PlatformLocalization(parts[0], availableLocations));
            }
        }
        
        return platformLocalizations;
    }
}