using FluentAssertions;
using FluentGarden.Infrastructure.Domain;
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
    public async Task ShouldGetDeviceByIp()
    {
        //Given
        string expectedIp = "123.0.0.1";
        GetRequiredService<IHubProvider>(out var service);
        Device expectedDevice = await AddDevice(service, expectedIp);

        //When
        Device outcome = await service.GetDeviceByIp(expectedIp);

        //Then
        outcome.Should().Be(expectedDevice);
    }

    [Test]
    public async Task ShouldSetDeviceName()
    {
        //Given
        string expectedIp = "123.0.0.1";
        string expectedName = "flowerpot";
        GetRequiredService<IHubProvider>(out var service);
        Device device = await AddDevice(service, expectedIp);

        //When
        Device outcome = await service.SetDeviceName(device, expectedName);

        //Then
        outcome.Name.Should().Be(expectedName);
    }

    [Test]
    public async Task ShouldRemoveDeviceFromHubAsync()
    {
        //Given
        string expectedIp = "123.0.0.1";
        GetRequiredService<IHubProvider>(out var service);
        await AddDevice(service, expectedIp);

        Device expectedDevice = await service.GetDeviceByIp(expectedIp);

        //When
        var outcome = await service.RemoveDeviceFromHub(expectedDevice);

        //Then
        outcome.Should().NotBeNull();
    }

    [Test]
    public async Task ShouldCreateGroup()
    {
        //Given
        string expectedName = "flowerpots";
        GetRequiredService<IHubProvider>(out var service);

        //When
        Group outcome = await service.CreateGroup(expectedName);

        //Then
        outcome.Should().NotBeNull();
        outcome.Name.Should().Be(expectedName);
    }

    [Test]
    public async Task ShouldDeleteGroup()
    {
        //Given
        GetRequiredService<IHubProvider>(out var service);
        var groupOne = await service.CreateGroup("Flower pots");
        var groupTwo = await service.CreateGroup("Greenhouse");

        //When
        List<Group> outcome = await service.DeleteGroup(groupOne);
        outcome.Should().HaveCount(1);
        outcome.First().Id.Should().Be(groupTwo.Id);
    }

    private async Task<Device> AddDevice(IHubProvider hub, string ip = "192.168.0.100", DeviceType type = DeviceType.Esp32)
    {
        Device device = new(type, ip);

        Device output = await hub.AddDeviceToHub(device);
        return output;
    }
}