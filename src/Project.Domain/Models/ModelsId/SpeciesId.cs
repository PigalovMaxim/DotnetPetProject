namespace Project.Domain.Models.ModelsId;

public record SpeciesId(Guid value)
{
    public Guid Value { get; private set; } = value;

    public static SpeciesId NewId() => new(Guid.NewGuid());

    public static SpeciesId EmptyId() => new(Guid.Empty);

    public static SpeciesId Create(Guid id) => new(id);
}
