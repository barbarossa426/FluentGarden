using FluentGarden.Repository.Models;

namespace FluentGarden.Infrastructure.Interfaces;

public interface IHubRepository
{
    Task<List<Device>> ListDevices();

    Task<List<Device>> RemoveDevice(Device device);

    Task<List<Device>> AddDevice(Device device);

    Task<Device> GetDeviceById(Guid id);

    Task<Device> GetDeviceByIp(string ip);

    Task<Device> SetDeviceName(Device device, string name);

    Task<Group> CreateGroup(string name, GroupType type);

    Task<List<Group>> DeleteGroup(Group group);
}