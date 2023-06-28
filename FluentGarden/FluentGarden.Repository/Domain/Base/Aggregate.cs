namespace FluentGarden.Infrastructure.Domain.Base;

public class Aggregate
{
    public Guid Id { get; set; } = Guid.NewGuid();
}