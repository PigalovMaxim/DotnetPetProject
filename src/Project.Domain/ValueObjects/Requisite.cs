using CSharpFunctionalExtensions;

namespace Project.Domain.ValueObjects;

public record Requisite
{
    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;

    private Requisite(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public static Result<Requisite> Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Requisite>("Name to photo cannot be empty");
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            return Result.Failure<Requisite>("Description to photo cannot be empty");
        }

        return new Requisite(name, description);
    }
}
