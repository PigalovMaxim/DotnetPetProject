namespace Project.Domain.Models;
public class SocialMedia
{
    public Guid Id { get; private set; }
    public string Link { get; private set; } = default!;
    public string Title { get; private set; } = default!;
}