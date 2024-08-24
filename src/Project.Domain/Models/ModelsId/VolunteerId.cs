namespace Project.Domain.Models.ModelsId;
public record VolunteerId(Guid value)
{
    public Guid Value { get; private set; } = value;

    public static VolunteerId NewId() => new(Guid.NewGuid());

    public static VolunteerId EmptyId() => new(Guid.Empty);

    public static VolunteerId Create(Guid id) => new(id);
}