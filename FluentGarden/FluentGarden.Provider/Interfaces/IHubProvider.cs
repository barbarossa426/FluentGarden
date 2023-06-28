using FluentGarden.Infrastructure.Domain;

namespace FluentGarden.Provider.Interfaces;

public interface IHubProvider
{
    Task<Device> AddDeviceToHub(Device device);

    Task<List<Device>> RemoveDeviceFromHub(Device device);

    Task TriggerDevice(Device device, params DeviceAction[] actions);

    Task<List<Device>> ListDevices();

    Task<Device> GetDeviceByMacAddress(string macAddress);

    Task<bool> Ping(string ip);

    Task<DateTime> GetHubTime();

    Task CheckIn(string ip);

    Task<Device> SetDeviceName(Device device, string name);

    Task<Group> CreateGroup(string name, GroupType type = GroupType.Device);

    Task<List<Group>> DeleteGroup(Group group);
}