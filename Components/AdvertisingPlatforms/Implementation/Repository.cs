using TestWebApp.Components.AdvertisingPlatforms.Api;
using TestWebApp.Components.AdvertisingPlatforms.Api.InternalModels;

namespace TestWebApp.Components.AdvertisingPlatforms.Implementation;

public class Repository : IRepository
{
    readonly IDbContext context;

    public Repository(IDbContext context)
    {
        this.context = context;
        LoadData();
    }
    
    public IReadOnlyList<PlatformLocalization> GetPlatformLocalizations() => context.PlatformLocalizations.Local.ToList();
    
    public void AddPlatformLocalization(PlatformLocalization localization)
    {
        context.PlatformLocalizations.Add(localization);
    }

    public void LoadData()
    {
        var loader = new ControllerTests();
        context.PlatformLocalizations.Local.Clear();
        context.PlatformLocalizations.AddRange(loader.Load());
    }
}