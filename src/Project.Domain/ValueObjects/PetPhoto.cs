using CSharpFunctionalExtensions;

namespace Project.Domain.ValueObjects;

public record PetPhoto
{
    private PetPhoto(string path, bool isMain)
    {
        Path = path;
        IsMain = isMain;
    }
    public string Path { get; set; } = default!;
    public bool IsMain { get; set; } = default!;

    public static Result<PetPhoto> Create(string path, bool isMain)
    {
        if(string.IsNullOrWhiteSpace(path))
        {
            return Result.Failure<PetPhoto>("Path to photo cannot be empty");
        }

        return new PetPhoto(path, isMain);
    }
}
