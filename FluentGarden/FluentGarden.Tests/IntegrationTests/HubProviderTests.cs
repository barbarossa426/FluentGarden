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
        string expectedMacAddress = "00-B0-D0-63-C2-26";

        Device expectedDevice = new(DeviceType.esp32, expectedMacAddress);
        GetRequiredService<IHubProvider>(out var service);

        //When
        var outcome = await service.AddDeviceToHub(expectedDevice);

        //Then
        outcome.Should().NotBeNull();
        outcome.MacAddress.Should().Be(expectedMacAddress);
    }

    [Test]
    public async Task ShouldGetDeviceByMacAddress()
    {
        //Given
        string expectedMacAddress = "00-B0-D0-63-C2-26";
        GetRequiredService<IHubProvider>(out var service);
        Device expectedDevice = await AddDevice(service, expectedMacAddress);

        //When
        Device outcome = await service.GetDeviceByMacAddress(expectedMacAddress);

        //Then
        outcome.Should().Be(expectedDevice);
    }

    [Test]
    public async Task ShouldSetDeviceName()
    {
        //Given
        string expectedMacAddress = "00-B0-D0-63-C2-26";
        string expectedName = "flowerpot";
        GetRequiredService<IHubProvider>(out var service);
        Device device = await AddDevice(service, expectedMacAddress);

        //When
        Device outcome = await service.SetDeviceName(device, expectedName);

        //Then
        outcome.Name.Should().Be(expectedName);
    }

    [Test]
    public async Task ShouldRemoveDeviceFromHubAsync()
    {
        //Given
        string expectedMackAddress = "00-B0-D0-63-C2-26";
        GetRequiredService<IHubProvider>(out var service);
        await AddDevice(service, expectedMackAddress);

        Device expectedDevice = await service.GetDeviceByMacAddress(expectedMackAddress);

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

    private async Task<Device> AddDevice(IHubProvider hub, string macAddress, DeviceType type = DeviceType.esp32)
    {
        Device device = new(type, macAddress);

        Device output = await hub.AddDeviceToHub(device);

        return output;
    }
}