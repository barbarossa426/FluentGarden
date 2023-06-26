using FluentAssertions;
using FluentGarden.Provider.Interfaces;
using FluentGarden.Tests.Base;

namespace FluentGarden.Tests.IntegrationTests;

public class HubTests : IntegrationTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task ShouldAddDeviceToHub()
    {
        //Given
        string expectedIp = "192.168.0.100";

        Device expectedDevice = new(DeviceType.Esp32, expectedIp);
        GetRequiredService<IHubProvider>(out var service);

        //When
        var outcome = await service.AddDeviceToHub(expectedDevice);

        //Then
        outcome.Should().NotBeNull();
        outcome.Ip.Should().Be(expectedIp);
    }

    [Test]
    public async Task ShouldRemoveDeviceFromHubAsync()
    {
        ////Given
        ////TODO add device
        //string expectedIp = "123.0.0.1";
        //HubProvider hubProvider = new();
        //Device expectedDevice = await hubProvider.GetDeviceByIp(expectedIp);

        ////When
        //var outcome = await hubProvider.RemoveDeviceFromHub(expectedDevice);

        ////Then
        //outcome.Should().Be(1);
        Assert.Fail();
    }
}