namespace FluentGarden.Repository.Models.Base;

public class AggregateRoot
{
    public Guid Id { get; set; } = Guid.NewGuid();
}