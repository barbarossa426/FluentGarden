using FluentGarden.Infrastructure.Domain;
using FluentGarden.Infrastructure.Interfaces;
using FluentGarden.Provider.Interfaces;

namespace FluentGarden.Provider;

public partial class HubProvider : IHubProvider
{
    public IHubRepository _hubRepository;

    public HubProvider(IHubRepository hubRepository)
    {
        _hubRepository = hubRepository;
    }

    public async Task<Device> AddDeviceToHub(Device device)
    {
        await _hubRepository.AddDevice(device);

        Device output = await _hubRepository.GetDeviceById(device.Id);
        return output;
    }

    public Task CheckIn(string ip)
    {
        throw new NotImplementedException();
    }

    public async Task<Group> CreateGroup(string name, GroupType type)
    {
        Group output = await _hubRepository.CreateGroup(name, type);
        return output;
    }

    public async Task<List<Group>> DeleteGroup(Group group)
    {
        var output = await _hubRepository.DeleteGroup(group);
        return output;
    }

    public async Task<Device> GetDeviceByIp(string ip)
    {
        var output = await _hubRepository.GetDeviceByIp(ip);
        return output;
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

    public async Task<List<Device>> RemoveDeviceFromHub(Device device)
    {
        var output = await _hubRepository.RemoveDevice(device);
        return output;
    }

    public async Task<Device> SetDeviceName(Device device, string name)
    {
        await _hubRepository.SetDeviceName(device, name);
        return device;
    }

    public Task TriggerDevice(Device device, params DeviceAction[] actions)
    {
        throw new NotImplementedException();
    }
}