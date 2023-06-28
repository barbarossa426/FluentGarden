using FluentGarden.Infrastructure.Domain;
using FluentGarden.Infrastructure.Interfaces;
using FluentGarden.Provider.Interfaces;

namespace FluentGarden.Provider;

public class GroupProvider : IGroupProvider
{
    public IGroupRepository _groupRepository;

    public GroupProvider(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task<Group> CreateGroupSchedule(Group group, DateTime startDate)
    {
        var output = await _groupRepository.CreateSchedule(group, startDate);
        return output;
    }

    public async Task<Group> DeleteGroupSchedule(Group group, Schedule schedule)
    {
        var output = await _groupRepository.DeleteSchedule(group, schedule);
        return output;
    }

    public async Task<Group> SetGroupScheduleDuration(Group group, int minutes)
    {
        var output = await _groupRepository.SetScheduleDuration(group, minutes);
        return output;
    }

    public async Task<Group> SetGroupScheduleInterval(Group group, int minutes)
    {
        var output = await _groupRepository.SetScheduleInterval(group, minutes);
        return output;
    }

    public async Task<Group> SetGroupScheduleStartTime(Group group, DateTime startDate)
    {
        var output = await _groupRepository.SetScheduleStartTime(group, startDate);
        return output;
    }
}