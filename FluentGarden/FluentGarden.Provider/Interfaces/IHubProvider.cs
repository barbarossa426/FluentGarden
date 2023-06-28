using FluentGarden.Infrastructure.Domain;
using FluentGarden.Provider.Models.Requests;
using FluentGarden.Provider.Models.Response;

namespace FluentGarden.Provider.Interfaces;

public interface IHubProvider
{
    Task<DeviceResponse> AddDeviceToHub(Device device);

    Task<List<DeviceResponse>> RemoveDeviceFromHub(string macAddress);

    Task TriggerDevice(Device device, params DeviceAction[] actions);

    Task<List<DeviceResponse>> ListDevices();

    Task<DeviceResponse> GetDeviceByMacAddress(string macAddress);

    Task<bool> Ping(string ip);

    Task<DateTime> GetHubTime();

    Task CheckIn(string ip);

    Task<DeviceResponse> SetDeviceName(string macAddress, string name);

    Task<Group> CreateGroup(string name, GroupType type = GroupType.Device);

    Task<List<Group>> DeleteGroup(Group group);
}