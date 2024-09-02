using CSharpFunctionalExtensions;
using Project.Domain.Models.ModelsId;

namespace Project.Domain.Models;

public class Species : Shared.Entity<SpeciesId>
{
    private readonly List<Breed> _breeds= [];

    public Species() : base() { }
    private Species(
        SpeciesId id,
        string title
        ) : base(id)
    {
        Title = title;
    }
    public string Title { get; private set; } = default!;
    public List<Breed> Breeds => _breeds;

    public static Result<Species> Create(
        SpeciesId id,
        string title
        )
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return Result.Failure<Species>("Title cannot be empty");
        }

        return new Species(
            id,
            title
            );
    }
}
