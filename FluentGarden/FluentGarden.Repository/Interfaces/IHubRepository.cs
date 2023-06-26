using FluentGarden.Repository.Models;

namespace FluentGarden.Repository.Interfaces;

public interface IHubRepository
{
    Task<List<Device>> ListDevices();

    Task<List<Device>> RemoveDevices();

    Task<List<Device>> AddDevice(Device device);

    Task<Device> GetDeviceById(Guid id);
}