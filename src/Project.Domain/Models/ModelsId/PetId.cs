namespace Project.Domain.Models.ModelsId;

public record PetId(Guid value)
{
    public Guid Value { get; private set; } = value;

    public static PetId NewId() => new(Guid.NewGuid());

    public static PetId EmptyId() => new(Guid.Empty);

    public static PetId Create(Guid id) => new(id);
}
