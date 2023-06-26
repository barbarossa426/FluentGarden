using FluentGarden.Repository.Models;

namespace FluentGarden.Repository.Interfaces;

public interface IHubRepository
{
    Task<List<Device>> ListDevices();

    Task<List<Device>> RemoveDevices(Device device);

    Task<List<Device>> AddDevice(Device device);

    Task<Device> GetDeviceById(Guid id);

    Task<Device> GetDeviceByIp(string ip);
    Task<Device> SetDeviceName(Device device, string name);
}