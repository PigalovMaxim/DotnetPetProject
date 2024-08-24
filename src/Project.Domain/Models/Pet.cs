using CSharpFunctionalExtensions;
using Project.Domain.Models.ModelsId;
using Project.Domain.Shared;
using Project.Domain.ValueObjects;

namespace Project.Domain.Models;

public class Pet: Shared.Entity<PetId>
{
    private readonly List<Requisite> _requisites = [];
    private readonly List<PetPhoto> _photos = [];

    public Pet() : base() { }
    private Pet(
        PetId id,
        string name,
        string species,
        string description,
        string breed,
        string color,
        string healthInfo,
        int weight,
        int height,
        string phone,
        bool isNeutered,
        DateTime birthday,
        bool isVaccinated,
        PetHelpStatus helpStatus,
        List<Requisite> requisites,
        List<PetPhoto> photos,
        DateTime dateCreate
        ) : base(id)
    {
        Name = name;
        Species = species;
        Description = description;
        Breed = breed;
        Color = color;
        HealthInfo = healthInfo;
        Weight = weight;
        Height = height;
        Phone = phone;
        IsNeutered = isNeutered;
        Birthday = birthday;
        IsVaccinated = isVaccinated;
        HelpStatus = helpStatus;
        _requisites = requisites;
        _photos = photos;
        DateCreate = dateCreate;
    }
    public string Name { get; private set; } = default!;
    public string Species { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public string Breed { get; private set; } = default!;
    public string Color { get; private set; } = default!;
    public string HealthInfo { get; private set; } = default!;
    public string Address { get; private set; } = default!;
    public int Weight { get; private set; } = default!;
    public int Height { get; private set; } = default!;
    public string Phone { get; private set; } = default!;
    public bool IsNeutered { get; private set; } = default!;
    public DateTime Birthday { get; private set; } = default!;
    public bool IsVaccinated { get; private set; } = default!;
    public PetHelpStatus HelpStatus { get; private set; } = default!;
    public List<Requisite> Requisites => _requisites;
    public List<PetPhoto> Photos => _photos;
    public DateTime DateCreate { get; private set; } = default!;

    public static Result<Pet> Create(
        PetId id,
        string name,
        string species,
        string description,
        string breed,
        string color,
        string healthInfo,
        int weight,
        int height,
        string phone,
        bool isNeutered,
        DateTime birthday,
        bool isVaccinated,
        PetHelpStatus helpStatus,
        List<Requisite> requisites,
        List<PetPhoto> photos,
        DateTime dateCreate
        )
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Pet>("Name cannot be empty");
        }
        if (string.IsNullOrWhiteSpace(species))
        {
            return Result.Failure<Pet>("Species cannot be empty");
        }
        if (string.IsNullOrWhiteSpace(description))
        {
            return Result.Failure<Pet>("Description cannot be empty");
        }
        if (string.IsNullOrWhiteSpace(breed))
        {
            return Result.Failure<Pet>("Breed cannot be empty");
        }
        if (string.IsNullOrWhiteSpace(color))
        {
            return Result.Failure<Pet>("Color cannot be empty");
        }
        if (string.IsNullOrWhiteSpace(healthInfo))
        {
            return Result.Failure<Pet>("HealthInfo cannot be empty");
        }
        if (weight < 0 && weight > Constants.PET_MAX_WEIGHT)
        {
            return Result.Failure<Pet>($"Weight cannot be less then zero or bigger then {Constants.PET_MAX_WEIGHT} kg");
        }
        if (height < 0 && height > Constants.PET_MAX_HEIGHT)
        {
            return Result.Failure<Pet>($"Height cannot be less then zero or bigger then {Constants.PET_MAX_HEIGHT} cm");
        }
        if (string.IsNullOrWhiteSpace(phone) || phone.Length != Constants.PHONE_LENGTH)
        {
            return Result.Failure<Pet>("Phone cannot be empty or phone should be format +7xxxxxxxxxx");
        }
        if (birthday.AddYears(100) <= DateTime.Now)
        {
            return Result.Failure<Pet>("Pet cannot be older then 100 years");
        }
        if (photos.Count > 5)
        {
            return Result.Failure<Pet>("You can upload only 5 pet photos");
        }

        return new Pet(
            id,
            name,
            species,
            description,
            breed,
            color,
            healthInfo,
            weight,
            height,
            phone,
            isNeutered,
            birthday,
            isVaccinated,
            helpStatus,
            requisites,
            photos,
            dateCreate
            );
    }
}
