using FluentGarden.Infrastructure.Domain.Base;

namespace FluentGarden.Infrastructure.Domain;

public record Device : ValueObject
{
    public string Name { get; private set; } = string.Empty;
    public DeviceType Type { get; private set; }
    public string Ip { get; private set; }

    public Device(DeviceType type, string ip)
    {
        Type = type;
        Ip = ip;
    }

    public Device SetName(string name)
    {
        Name = name;
        return this;
    }
}