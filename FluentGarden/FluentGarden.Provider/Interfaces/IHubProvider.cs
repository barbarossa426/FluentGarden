using FluentGarden.Repository.Models;

namespace FluentGarden.Provider.Interfaces;

public interface IHubProvider
{
    Task<Hub> AddDeviceToHub(Device device);

    Task<int> RemoveDeviceFromHub(Device device);

    Task TriggerDevice(Device device, params DeviceAction[] actions);

    Task<List<Device>> ListDevices();

    Task<Device> GetDeviceByIp(string ip);

    Task<bool> Ping(string ip);

    Task<DateTime> GetHubTime();

    Task CheckIn(string ip);
}