using FluentAssertions;
using FluentGarden.Provider.Models.Base;
using FluentGarden.Provider.Models.Requests;

namespace FluentGarden.Tests.UnitTests;

public class MapperTests
{
    [Test]
    public async Task ShouldMapDviceRequestAsDeviceDomainEntity()
    {
        //Given
        string expectedMacAddress = "00-B0-D0-63-C2-26";
        string expectedType = "esp32";
        DeviceRequest request = new DeviceRequest(expectedMacAddress, expectedType);

        //When
        Device outcome = request.AsDomainEntity<Device>();

        //Then
        outcome.MacAddress.Should().Be(expectedMacAddress);
    }
}