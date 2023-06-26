using FluentAssertions;

namespace FluentGarden.Tests;

public class HubTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ShouldAddDeviceToHub()
    {
        //Given
        string expectedIp = "192.168.0.100";

        Device expectedDevice = new(DeviceType.Esp32, expectedIp);
        HubProvider provider = new();

        //When
        provider.AddDeviceToHub(expectedDevice);

        //Then
    }

    [Test]
    public async Task ShouldRemoveDeviceFromHubAsync()
    {
        //Given
        //TODO add device
        string expectedIp = "123.0.0.1";
        HubProvider hubProvider = new();
        Device expectedDevice = await hubProvider.GetDeviceByIp(expectedIp);

        //When
        var outcome = await hubProvider.RemoveDeviceFromHub(expectedDevice);

        //Then
        outcome.Should().Be(1);
    }
}