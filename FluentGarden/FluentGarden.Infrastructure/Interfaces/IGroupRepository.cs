using FluentGarden.Repository.Models;

namespace FluentGarden.Infrastructure.Interfaces;

public interface IGroupRepository
{
    Task<Group> CreateSchedule(Group group, DateTime startDate);

    Task<Group> DeleteSchedule(Group group, Schedule schedule);

    Task<Group> SetScheduleStartTime(Group group, DateTime startDate);

    Task<Group> SetScheduleInterval(Group group, int minutes);

    Task<Group> SetScheduleDuration(Group group, int minutes);
}