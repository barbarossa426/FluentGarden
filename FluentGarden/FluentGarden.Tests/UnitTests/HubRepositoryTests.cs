using FluentAssertions;
using FluentGarden.Repository;

namespace FluentGarden.Tests.UnitTests;

public class HubRepositoryTests
{
    [Test]
    public async Task ShouldWriteToDataBaseFile()
    {
        //Given
        string expectedMacAddress = "00-B0-D0-63-C2-26";
        Device expectedDevice = new(DeviceType.esp32, expectedMacAddress);
        HubRepository repository = new("FluentGarden.Infrastructure.Database.json");

        //When
        var devices = await repository.AddDevice(expectedDevice);

        //Then
        var outcome = devices.FirstOrDefault(expectedDevice);

        outcome.Should().NotBeNull();
        outcome.MacAddress.Should().Be(expectedMacAddress);
    }
}