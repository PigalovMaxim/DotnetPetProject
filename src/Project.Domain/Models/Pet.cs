namespace Project.Domain.Models
{
    public class Pet
    {
        private readonly List<Requisite> _requisites = [];
        public Guid Id { get; set; }
        public string Name { get; private set; } = default!;
        public string Species { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public string Breed { get; private set; } = default!;
        public string Color { get; private set; } = default!;
        public string HealthInfo { get; private set; } = default!;
        public string Address { get; private set; } = default!;
        public int Weight { get; private set; } = default!;
        public int Height { get; private set; } = default!;
        public int Phone { get; private set; } = default!;
        public bool IsNeutered { get; private set; } = default!;
        public DateTime Birthday { get; private set; } = default!;
        public bool IsVaccinated { get; private set; } = default!;
        public PetHelpStatus HelpStatus { get; private set; } = default!;
        public List<Requisite> Requisites => _requisites;
        public DateTime DateCreate { get; private set; } = default!;
    }
}
