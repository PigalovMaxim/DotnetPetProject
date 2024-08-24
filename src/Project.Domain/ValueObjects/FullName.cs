using CSharpFunctionalExtensions;

namespace Project.Domain.ValueObjects;

public record FullName
{
    public string FirstName { get; private set; } = default!;
    public string MiddleName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;

    private FullName(string firstName, string middleName, string lastName)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
    }

    public static Result<FullName> Create(string firstName, string middleName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return Result.Failure<FullName>("FirstName to photo cannot be empty");
        }

        if (string.IsNullOrWhiteSpace(middleName))
        {
            return Result.Failure<FullName>("MiddleName to photo cannot be empty");
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            return Result.Failure<FullName>("LastName to photo cannot be empty");
        }

        return new FullName(firstName, middleName, lastName);
    }
}