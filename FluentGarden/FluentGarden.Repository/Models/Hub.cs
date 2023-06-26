using FluentGarden.Repository.Exceptions;

namespace FluentGarden.Repository.Models;

public class Hub
{
    public string ConnectionString { get; private set; }
    public virtual IReadOnlyList<Device> Devices => _devices.AsReadOnly();
    private readonly List<Device> _devices = new List<Device>();

    public Hub(string connectionsTring = "FluentGarden.Repository.Database.json")
    {
        ConnectionString = connectionsTring;
    }

    public Hub AddDevice(Device device)
    {
        _devices.Add(device);
        return this;
    }

    public Hub RemoveDevice(Device device)
    {
        bool result = _devices.Remove(device);
        if (result is false)
        {
            throw new HubException($"Device with id {device.Id} could not be removed");
        }

        return this;
    }

    public Device GetDevice(string ip)
    {
        var output = _devices.FirstOrDefault(x => x.Ip == ip);
        if (output == null)
        {
            throw new HubException($"Device with ip {ip} could not be found");
        }
        return output;
    }

    public Device GetDevice(Guid id)
    {
        var output = _devices.FirstOrDefault(x => x.Id == id);
        if (output == null)
        {
            throw new HubException($"Device with id {id} could not be found");
        }
        return output;
    }
}