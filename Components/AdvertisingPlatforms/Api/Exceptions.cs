using TestWebApp.Helpers.BasicException;

namespace TestWebApp.Components.AdvertisingPlatforms.Api;

public class PlatformLocalizationAlreadyDefinedExc : BasicException
{
    public PlatformLocalizationAlreadyDefinedExc(string platform)
        : base("platform_localization-001", "Localization for platform '{platform}' is already defined.") { }
}

public class SearchPlatformWithNoLocationDefinedExc : BasicException
{
    public SearchPlatformWithNoLocationDefinedExc()
        : base("platform_localization-002", "Localization has to be defined to search for platforms.") { }
}

public class AddPlatformWithNoLocationDefinedExc : BasicException
{
    public AddPlatformWithNoLocationDefinedExc(string platform)
        : base("platform_localization-003", "To add platform '{platform}' localization has to be defined.") { }
}

public class AddPlatformWithNoNameExc : BasicException
{
    public AddPlatformWithNoNameExc()
        : base("platform_localization-004", "Define platform to add localization.") { }
}
