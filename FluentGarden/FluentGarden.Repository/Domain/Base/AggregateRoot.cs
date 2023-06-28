namespace FluentGarden.Infrastructure.Domain.Base;

public class AggregateRoot
{
    public Guid Id { get; set; } = Guid.NewGuid();
}