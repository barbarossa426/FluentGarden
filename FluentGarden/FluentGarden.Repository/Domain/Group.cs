﻿using FluentGarden.Infrastructure.Domain.Base;
using FluentGarden.Infrastructure.Exceptions;

namespace FluentGarden.Infrastructure.Domain;

public class Group : Aggregate
{
    public string Name { get; private set; } = string.Empty;
    public virtual IReadOnlyList<Device> Devices => _devices.AsReadOnly();

    private readonly List<Device> _devices = new List<Device>();
    public GroupType Type { get; private set; } = GroupType.Device;
    public virtual Schedule? Schedule { get; private set; }
    public virtual Hub Hub { get; private set; }

    public Group(Hub hub, string name)
    {
        if (hub is null)
        {
            throw new GroupException($"{nameof(hub)} cannot be null or empty");
        }
        if (string.IsNullOrEmpty(name))
        {
            throw new GroupException($"{nameof(name)} cannot be null or empty");
        }
        Hub = hub;
        Name = name;
    }

    public Group SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new GroupException($"{nameof(name)} cannot be null or empty");
        }

        Name = name; return this;
    }

    public Group SetType(GroupType type)
    {
        Type = type;
        return this;
    }

    public Group AddDevice(Device device)
    {
        _devices.Add(device);
        return this;
    }

    public Group CreateSchedule(DateTime startTime)
    {
        Schedule = new Schedule(startTime);
        return this;
    }

    public Group SetScheduleInterval(int minutes)
    {
        if (Schedule is null)
        {
            throw new GroupException($"{nameof(Schedule)} does not exist");
        }
        Schedule.SetInterval(minutes);
        return this;
    }

    public Group SetScheduleStartTime(DateTime time)
    {
        if (Schedule is null)
        {
            throw new GroupException($"{nameof(Schedule)} does not exist");
        }
        Schedule.SetStartTime(time);
        return this;
    }

    public Group SetScheduleDuration(int minutes)
    {
        if (Schedule is null)
        {
            throw new GroupException($"{nameof(Schedule)} does not exist");
        }
        Schedule.SetDuration(minutes);
        return this;
    }
}