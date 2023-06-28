using FluentAssertions;
using FluentGarden.Provider.Interfaces;
using FluentGarden.Tests.Base;

namespace FluentGarden.Tests.IntegrationTests;

public class GroupProviderTests : IntegrationTest
{
    [Test]
    public async Task ShouldCreateSchedule()
    {
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

    [Test]
    public async Task ShouldCreateGroup()
    {
        //Given
        string expectedGroupName = "flowerpots";
        GetRequiredService<IHubProvider>(out var hubService);

        //When
        var outcome = await hubService.CreateGroup(expectedGroupName);

        //Then
        outcome.Should().NotBeNull();
        outcome.Name.Should().Be(expectedGroupName);
        outcome.Schedule.Should().Be(null);
    }

    [Test]
    public async Task ShouldDeleteGroup()
    {
        //Given
        string expectedGroupName = "flowerpots";
        string expectedGroupName2 = "greenhouse";
        GetRequiredService<IHubProvider>(out var hubService);
        var flowerpots = await hubService.CreateGroup(expectedGroupName);
        var greenhouse = await hubService.CreateGroup(expectedGroupName2);

        //When
        var outcome = await hubService.DeleteGroup(flowerpots);

        //Then
        outcome.Should().HaveCount(1);
        outcome.First().Name.Should().Be(expectedGroupName2);
    }

    [Test]
    public async Task ShouldSetScheduleInterval()
    {
        //Given
        string groupName = "flowerpots";
        int expectedInterval = 60;
        GetRequiredService<IHubProvider>(out var hubService);
        GetRequiredService<IGroupProvider>(out var groupService);
        var group = await hubService.CreateGroup(groupName);

        group.CreateSchedule(DateTime.UtcNow);

        //When
        var outcome = await groupService.SetGroupScheduleInterval(group, expectedInterval);

        //Then
        outcome.Schedule.Interval.Should().Be(expectedInterval);
    }

    [Test]
    public async Task ShouldSetScheduleDuration()
    {
        //Given
        string groupName = "flowerpots";
        int expectedDuration = 10;
        GetRequiredService<IHubProvider>(out var hubService);
        GetRequiredService<IGroupProvider>(out var groupService);
        var group = await hubService.CreateGroup(groupName);

        group.CreateSchedule(DateTime.UtcNow);

        //When
        var outcome = await groupService.SetGroupScheduleDuration(group, expectedDuration);

        //Then
        outcome.Schedule.Duration.Should().Be(expectedDuration);
    }
}