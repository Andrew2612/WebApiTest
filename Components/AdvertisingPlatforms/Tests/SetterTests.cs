using Components.AdvertisingPlatforms.Implementation;
using Moq;
using NUnit.Framework;
using TestWebApp.Components.AdvertisingPlatforms.Api;
using InternalModels = TestWebApp.Components.AdvertisingPlatforms.Api.InternalModels;

namespace TestWebApp.Components.AdvertisingPlatforms.Tests;

[TestFixture]
public class SetterTests
{
    Mock<IRepository> repositoryMock;
    PlatformLocalizationSetter platformLocalizationSetter;

    [SetUp]
    public void SetUp()
    {
        repositoryMock = new Mock<IRepository>();
        platformLocalizationSetter = new PlatformLocalizationSetter(repositoryMock.Object);
    }

    [Test]
    public void AddPlatformLocalizationTest()
    {
        repositoryMock.Setup(m => m.GetPlatformLocalizations()).Returns(new List<InternalModels.PlatformLocalization>()
        {
            new ("name", new string[] { "availableLocation1", "availableLocation2" })
        });

        Assert.Throws<AddPlatformWithNoNameExc>(() => platformLocalizationSetter.AddPlatformLocalization("", new string[] { "" }));
        Assert.Throws<AddPlatformWithNoLocationDefinedExc>(() => platformLocalizationSetter.AddPlatformLocalization("n", new string[] { }));
        Assert.Throws<PlatformLocalizationAlreadyDefinedExc>(() => platformLocalizationSetter.AddPlatformLocalization("name", new string[] { "location" }));
    }
}

