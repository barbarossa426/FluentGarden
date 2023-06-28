using FluentGarden.Infrastructure.Domain;

namespace FluentGarden.Infrastructure.Interfaces;

public interface IHubRepository
{
    Task<List<Device>> ListDevices();

    Task<List<Device>> RemoveDevice(Device device);

    Task<List<Device>> AddDevice(Device device);

    Task<Device> GetDeviceById(Guid id);

    Task<Device> GetDeviceByMacAddress(string macAddress);

    Task<Device> SetDeviceName(Device device, string name);

    Task<Group> CreateGroup(string name, GroupType type);

    Task<List<Group>> DeleteGroup(Group group);
}