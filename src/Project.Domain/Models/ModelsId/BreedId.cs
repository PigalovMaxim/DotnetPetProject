namespace Project.Domain.Models.ModelsId;

public record BreedId(Guid value)
{
    public Guid Value { get; private set; } = value;

    public static BreedId NewId() => new(Guid.NewGuid());

    public static BreedId EmptyId() => new(Guid.Empty);

    public static BreedId Create(Guid id) => new(id);
}
