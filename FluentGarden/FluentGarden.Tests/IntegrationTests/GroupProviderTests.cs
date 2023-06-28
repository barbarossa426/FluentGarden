using FluentAssertions;
using FluentGarden.Infrastructure.Domain;
using FluentGarden.Provider.Interfaces;
using FluentGarden.Tests.Base;

namespace FluentGarden.Tests.IntegrationTests;

public class GroupProviderTests : IntegrationTest
{
    [Test]
    public async Task ShouldCreateSchedule()
    {
        Assert.Fail();
        //Given
        DateTime expectedStart = DateTime.UtcNow;
        string expectedGroupName = "flowerpots";
        GetRequiredService<IHubProvider>(out var hubService);
        GetRequiredService<IGroupProvider>(out var groupService);

        hubService.CreateGroup(expectedGroupName);

        Group expectedGroup = await hubService.CreateGroup(expectedGroupName);

        //When
        Group outcome = await groupService.CreateGroupSchedule(expectedGroup, expectedStart);

        //Then
        outcome.Schedule.Should().NotBeNull();
        outcome.Schedule!.Start.Should().Be(expectedStart);
    }
}