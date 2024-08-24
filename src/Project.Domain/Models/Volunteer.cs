using CSharpFunctionalExtensions;
using Project.Domain.Models.ModelsId;
using Project.Domain.ValueObjects;

namespace Project.Domain.Models;

public class Volunteer: Shared.Entity<VolunteerId>
{
    private readonly List<SocialMedia> _socials = [];
    private readonly List<Requisite> _requisites = [];
    private readonly List<Pet> _pets = [];

    public Volunteer(): base() { }
    private Volunteer(
        VolunteerId id,
        FullName fullName,
        string email,
        byte experience
        ) : base(id)
    {
        FullName = fullName;
        Email = email;
        Experience = experience;
    }
    public FullName FullName { get; private set; }
    public string Email { get; private set; } = default!;
    public byte Experience { get; private set; } = default!;
    public List<SocialMedia> Socials => _socials;
    public List<Requisite> Requisites => _requisites;
    public List<Pet> Pets => _pets;
    public int HelpedPetsCount() => _pets.Select(x => x.HelpStatus == PetHelpStatus.FoundAHome).Count();
    public int NeedHelpPetsCount() => _pets.Select(x => x.HelpStatus == PetHelpStatus.NeedsHelp).Count();
    public int SeeksHomePetsCount() => _pets.Select(x => x.HelpStatus == PetHelpStatus.SeeksAHome).Count();

    public static Result<Volunteer> Create(
        VolunteerId id,
        string firstName,
        string middleName,
        string lastName,
        string email,
        byte experience
        )
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return Result.Failure<Volunteer>("FirstName cannot be empty");
        }

        if (string.IsNullOrWhiteSpace(middleName))
        {
            return Result.Failure<Volunteer>("MiddleName cannot be empty");
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            return Result.Failure<Volunteer>("LastName cannot be empty");
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            return Result.Failure<Volunteer>("Email cannot be empty");
        }

        if (experience < 0)
        {
            return Result.Failure<Volunteer>("Experience cannot be less then zero");
        }

        var fullName = FullName.Create(firstName, middleName, lastName);

        if (fullName.IsFailure)
        {
            return Result.Failure<Volunteer>("FullName is not valid");
        }

        return new Volunteer(
            id,
            fullName.Value,
            email,
            experience
            );
    }
}
