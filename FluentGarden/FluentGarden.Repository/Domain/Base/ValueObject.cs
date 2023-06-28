namespace FluentGarden.Infrastructure.Domain.Base;

public record ValueObject
{
    public Guid Id { get; set; } = Guid.NewGuid();
}