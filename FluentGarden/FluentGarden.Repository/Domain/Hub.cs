using FluentGarden.Infrastructure.Domain.Base;
using FluentGarden.Infrastructure.Exceptions;

namespace FluentGarden.Infrastructure.Domain;

public class Hub : AggregateRoot
{
    public string ConnectionString { get; private set; }
    public virtual IReadOnlyList<Device> Devices => _devices.AsReadOnly();
    private readonly List<Device> _devices = new List<Device>();
    public virtual IReadOnlyList<Group> Groups => _groups.AsReadOnly();

    private readonly List<Group> _groups = new List<Group>();

    public Hub(string connectionsTring = "FluentGarden.Infrastructure.Database.json")
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

    public Device GetDevice(string macAddress)
    {
        var output = _devices.FirstOrDefault(x => x.MacAddress == macAddress);
        if (output == null)
        {
            throw new HubException($"Device with {macAddress} could not be found");
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

    public Group AddGroup(string name, GroupType type = GroupType.Device)
    {
        if (string.IsNullOrWhiteSpace(name) is true)
        {
            throw new HubException($"{nameof(name)} needs to be provided");
        }

        Group input = new(this, name);
        input.SetType(type);
        _groups.Add(input);

        return input;
    }

    public List<Group> DeleteGroup(Group group)
    {
        if (_groups.Contains(group) is false)
        {
            throw new HubException($"Group not found {nameof(group)}");
        }

        _groups.Remove(group);
        return _groups;
    }
}