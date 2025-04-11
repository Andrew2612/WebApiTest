using Components.AdvertisingPlatforms.Implementation;
using Moq;
using NUnit.Framework;
using TestWebApp.Components.AdvertisingPlatforms.Api;
using ExternalModels = TestWebApp.Components.AdvertisingPlatforms.Api.ExternalModels;
using InternalModels = TestWebApp.Components.AdvertisingPlatforms.Api.InternalModels;

namespace TestWebApp.Components.AdvertisingPlatforms.Tests;

[TestFixture]
public class GetterTests
{
    Mock<IRepository> repositoryMock;
    PlatformLocalizationGetter platformLocalizationGetter;

    [SetUp]
    public void SetUp()
    {
        repositoryMock = new Mock<IRepository>();
        platformLocalizationGetter = new PlatformLocalizationGetter(repositoryMock.Object);
    }

    [Test]
    public void GetPlatformLocalizationsTest()
    {
        repositoryMock.Setup(m => m.GetPlatformLocalizations()).Returns(new List<InternalModels.PlatformLocalization>()
        {
            new InternalModels.PlatformLocalization("name", new string[] { "availableLocation1", "availableLocation2" })
        });

        IReadOnlyList<ExternalModels.PlatformLocalization> platformLocalizations = platformLocalizationGetter.GetPlatformLocalizations();

        Assert.That(platformLocalizations.Count == 1);
        Assert.That(platformLocalizations[0].PlatformName == "name");
        Assert.That(platformLocalizations[0].AvailableLocations.Length == 2);
        Assert.That(platformLocalizations[0].AvailableLocations[0] == "availableLocation1");
        Assert.That(platformLocalizations[0].AvailableLocations[1] == "availableLocation2");
    }

    [Test]
    public void GetAvailablePlatformsTest()
    {
        repositoryMock.Setup(m => m.GetPlatformLocalizations()).Returns(new List<InternalModels.PlatformLocalization>()
        {
            new ("name", new string[] { "availableLocation1", "availableLocation2" }),
            new ("extra_name", new string[] { "extra_availableLocation" }),
        });

        Assert.Throws<SearchPlatformWithNoLocationDefinedExc>(() => platformLocalizationGetter.GetAvailablePlatforms(""));

        IReadOnlyList<string> availablePlatforms = platformLocalizationGetter.GetAvailablePlatforms("availableLocation1");

        Assert.That(availablePlatforms.Count == 1);
        Assert.That(availablePlatforms[0] == "name");
    }
}

