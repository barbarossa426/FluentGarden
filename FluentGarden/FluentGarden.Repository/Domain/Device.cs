using FluentGarden.Infrastructure.Domain.Base;

namespace FluentGarden.Infrastructure.Domain;

public record Device : ValueObject
{
    public string Name { get; private set; } = string.Empty;
    public DeviceType Type { get; private set; }
    public string MacAddress { get; private set; } //TODO add support for mac address DHCP https://sv.wikipedia.org/wiki/Dynamic_Host_Configuration_Protocol
    public string Ip { get; private set; }

    public Device(DeviceType type, string macAddress)
    {
        Type = type;
        MacAddress = macAddress;
    }

    public Device SetName(string name)
    {
        Name = name;
        return this;
    }   
}