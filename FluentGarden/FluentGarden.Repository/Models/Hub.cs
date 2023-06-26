namespace FluentGarden.Repository.Models;

public class Hub
{
    public virtual IReadOnlyList<Device> Devices => _devices.AsReadOnly();
    private readonly List<Device> _devices = new List<Device>();

    public Hub AddDevice(Device device)
    {
        _devices.Add(device);
        return this;
    }

    public Hub RemoveDevice(Device device)
    {
        _devices.Remove(device);
        return this;
    }
}