using FluentGarden.Repository.Models;

namespace FluentGarden.Provider.Interfaces;

public interface IGroupProvider
{
    Task<Group> CreateGroupSchedule(Group group, DateTime startDate);

    Task<Group> DeleteGroupSchedule(Group group, Schedule schedule);

    Task<Group> SetGroupScheduleStartTime(Group group, DateTime startDate);

    Task<Group> SetGroupScheduleInterval(Group group, int minutes);

    Task<Group> SetGroupScheduleDuration(Group group, int minutes);
}