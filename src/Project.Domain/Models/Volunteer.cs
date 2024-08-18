namespace Project.Domain.Models;

public class Volunteer
{
    private readonly List<SocialMedia> _socials = [];
    private readonly List<Requisite> _requisites = [];
    private readonly List<Pet> _pets = [];
    public Guid Id { get; set; }
    public string FirstName { get; private set; } = default!;
    public string MiddleName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string FullName => $"{FirstName} {MiddleName} {LastName}";
    public string Email { get; private set; } = default!;
    public byte Experience { get; private set; } = default!;
    public List<SocialMedia> Socials => _socials;
    public List<Requisite> Requisites => _requisites;
    public List<Pet> Pets => _pets;
    public int HelpedPetsCount() => _pets.Select(x => x.HelpStatus == PetHelpStatus.FoundAHome).Count();
    public int NeedHelpPetsCount() => _pets.Select(x => x.HelpStatus == PetHelpStatus.NeedsHelp).Count();
    public int SeeksHomePetsCount() => _pets.Select(x => x.HelpStatus == PetHelpStatus.SeeksAHome).Count();

}
