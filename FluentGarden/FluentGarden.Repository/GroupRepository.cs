using FluentGarden.Repository.Interfaces;
using FluentGarden.Repository.Models;

namespace FluentGarden.Repository
{
    public partial class HubRepository : IGroupRepository
    {
        public Task<Group> CreateSchedule(Group group, DateTime startDate)
        {
            Group output = group.CreateSchedule(startDate);
            return Task.FromResult(output);
        }

        public Task<Group> DeleteSchedule(Group group, Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public Task<Group> SetScheduleDuration(Group group, int minutes)
        {
            Group output = group.SetScheduleDuration(minutes);
            return Task.FromResult(output);
        }

        public Task<Group> SetScheduleInterval(Group group, int minutes)
        {
            Group output = group.SetScheduleInterval(minutes);
            return Task.FromResult(output);
        }

        public Task<Group> SetScheduleStartTime(Group group, DateTime startDate)
        {
            Group output = group.SetScheduleStartTime(startDate);
            return Task.FromResult(output);
        }
    }
}