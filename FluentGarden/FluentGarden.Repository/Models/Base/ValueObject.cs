namespace FluentGarden.Repository.Models.Base;

public record ValueObject
{
    public Guid Id { get; set; } = Guid.NewGuid();
}