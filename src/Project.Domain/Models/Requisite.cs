namespace Project.Domain.Models
{
    public class Requisite
    {
        public Guid Id { get; set; }
        public string Name { get; private set; } = default!;
        public string Description { get; private set; } = default!;
    }
}
