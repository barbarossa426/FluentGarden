using FluentGarden.Infrastructure.Domain.Base;
using FluentGarden.Infrastructure.Exceptions;

namespace FluentGarden.Infrastructure.Domain;

public record Schedule : ValueObject
{
    public DateTime Start { get; private set; }
    public int Interval { get; private set; }
    public int Duration { get; private set; }
    public Schedule(DateTime start, int interval = 5, int duration = 10)
    {
        if (start < DateTime.UtcNow)
        {
            throw new ScheduleException($"Start date cannot be in the past. {nameof(start)}");
        }

        Start = start;
        Interval = interval;
        Duration = duration;
    }

    public Schedule SetStartTime(DateTime start)
    {
        if (start < DateTime.UtcNow)
        {
            throw new ScheduleException($"Start date cannot be in the past. {nameof(start)}");
        }
        Start = start;
        return this;
    }
    public Schedule SetInterval(int minutes)
    {
        if (minutes <= 0)
        {
            throw new ScheduleException($"minutes cannot be in the past. {nameof(minutes)}");
        }
        Interval = minutes;
        return this;
    }
    public Schedule SetDuration(int minutes)
    {
        if (minutes <= 0)
        {
            throw new ScheduleException($"minutes cannot be in the past. {nameof(minutes)}");
        }
        Duration = minutes;
        return this;
    }
}