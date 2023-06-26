﻿using FluentAssertions;
using FluentGarden.Repository;

namespace FluentGarden.Tests;

public class HubRepositoryTests
{
    [Test]
    public async Task ShouldWriteToDataBaseFile()
    {
        //Given
        string expectedDeviceip = "123.123.123.10";
        Device expectedDevice = new(DeviceType.Esp32, expectedDeviceip);
        HubRepository repository = new();

        //When
        var devices = await repository.AddDevice(expectedDevice);

        //Then
        var outcome = devices.FirstOrDefault(expectedDevice);

        outcome.Should().NotBeNull();
        outcome.Ip.Should().Be(expectedDeviceip);
    }
}