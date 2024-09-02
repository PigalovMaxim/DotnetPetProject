using CSharpFunctionalExtensions;
using Project.Domain.Models.ModelsId;

namespace Project.Domain.ValueObjects;

public record PetEntitiesKeys
{
    private PetEntitiesKeys(Guid BreedId, SpeciesId SpeciesId)
    {
        BreedId = BreedId;
        SpeciesId = SpeciesId;
    }
    public Guid BreedId { get; private set; } = default!;
    public SpeciesId SpeciesId { get; private set; }

    public static Result<PetEntitiesKeys> Create(Guid BreedId, SpeciesId SpeciesId)
    {
        return new PetEntitiesKeys(BreedId, SpeciesId);
    }
}
