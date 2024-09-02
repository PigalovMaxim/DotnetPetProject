using CSharpFunctionalExtensions;
using Project.Domain.Models.ModelsId;

namespace Project.Domain.Models;

public class Breed : Shared.Entity<BreedId>
{
    public Breed() : base() { }
    private Breed(
        BreedId id,
        string title
        ) : base(id)
    {
        Title = title;
    }
    public string Title { get; private set; } = default!;

    public static Result<Breed> Create(
        BreedId id,
        string title
        )
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return Result.Failure<Breed>("Title cannot be empty");
        }

        return new Breed(
            id,
            title
            );
    }
}
