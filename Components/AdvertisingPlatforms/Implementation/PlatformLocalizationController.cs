using Components.AdvertisingPlatforms.Implementation;
using Microsoft.AspNetCore.Mvc;
using TestWebApp.Components.AdvertisingPlatforms.Api;
using TestWebApp.Components.AdvertisingPlatforms.Api.ExternalModels;
using TestWebApp.Components.AdvertisingPlatforms.Implementation;

namespace TestWebApp.Implementation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlatformLocalizationController : ControllerBase, IController
    {
        readonly IRepository repository;

        readonly PlatformLocalizationGetter platformLocalizationGetter;
        readonly PlatformLocalizationSetter platformLocalizationSetter;

        public PlatformLocalizationController(IDbContext context)
        {   
            repository = new Repository(context);

            platformLocalizationGetter = new PlatformLocalizationGetter(repository);
            platformLocalizationSetter = new PlatformLocalizationSetter(repository);
        }

        [HttpPut]
        public void LoadData()
        {
            platformLocalizationSetter.LoadData();
        }

        [HttpGet]
        public IReadOnlyList<PlatformLocalization> GetPlatformLocalizations()
            => platformLocalizationGetter.GetPlatformLocalizations(); 

        [HttpGet("{location}")]
        public IReadOnlyList<string> GetAvailablePlatforms(string location)
            => platformLocalizationGetter.GetAvailablePlatforms(location);

        [HttpPatch]
        public void AddPlatformLocalization(string platformName, string[] availableLocations)
            => platformLocalizationSetter.AddPlatformLocalization(platformName, availableLocations);
    }
}
