using FluentGarden.Infrastructure.Domain;
using FluentGarden.Infrastructure.Interfaces;
using FluentGarden.Provider.Interfaces;
using FluentGarden.Provider.Models.Base;
using FluentGarden.Provider.Models.Response;

namespace FluentGarden.Provider;

public class HubProvider : IHubProvider
{
    public IHubRepository _hubRepository;

    public HubProvider(IHubRepository hubRepository)
    {
        _hubRepository = hubRepository;
    }

    public async Task<DeviceResponse> AddDeviceToHub(Device device)
    {
        await _hubRepository.AddDevice(device);

        Device output = await _hubRepository.GetDeviceById(device.Id);
        return output.AsResponse<DeviceResponse>();
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

    public async Task<DeviceResponse> GetDeviceByMacAddress(string macAddress)
    {
        var output = await _hubRepository.GetDeviceByMacAddress(macAddress);
        return output.AsResponse<DeviceResponse>();
    }

    public Task<DateTime> GetHubTime()
    {
        throw new NotImplementedException();
    }

    public Task<List<DeviceResponse>> ListDevices()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Ping(string ip)
    {
        throw new NotImplementedException();
    }

    public async Task<List<DeviceResponse>> RemoveDeviceFromHub(string macAddress)
    {
        Device request = await _hubRepository.GetDeviceByMacAddress(macAddress);
        List<Device> devices = await _hubRepository.RemoveDevice(request);

        var output = new List<DeviceResponse>();
        devices.ForEach((device) =>
        {
            output.Add(device.AsResponse<DeviceResponse>());
        });

        return output;
    }

    public async Task<DeviceResponse> SetDeviceName(string macAddress, string name)
    {
        var request = await _hubRepository.GetDeviceByMacAddress(macAddress);

        var output = await _hubRepository.SetDeviceName(request, name);

        return output.AsResponse<DeviceResponse>();
    }

    public Task TriggerDevice(Device device, params DeviceAction[] actions)
    {
        throw new NotImplementedException();
    }
}