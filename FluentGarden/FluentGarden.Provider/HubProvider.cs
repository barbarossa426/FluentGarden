using FluentGarden.Provider.Interfaces;
using FluentGarden.Repository.Models;

namespace FluentGarden.Provider;

public class HubProvider : IHubProvider
{
    public Task<Hub> AddDeviceToHub(Device device)
    {
        throw new NotImplementedException();
    }

    public Task CheckIn(string ip)
    {
        throw new NotImplementedException();
    }

    public Task<Device> GetDeviceByIp(string ip)
    {
        throw new NotImplementedException();
    }

    public Task<DateTime> GetHubTime()
    {
        throw new NotImplementedException();
    }

    public Task<List<Device>> ListDevices()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Ping(string ip)
    {
        throw new NotImplementedException();
    }

    public Task<int> RemoveDeviceFromHub(Device device)
    {
        throw new NotImplementedException();
    }

    public Task TriggerDevice(Device device, params DeviceAction[] actions)
    {
        throw new NotImplementedException();
    }
}