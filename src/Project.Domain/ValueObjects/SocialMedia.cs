using CSharpFunctionalExtensions;
using System.Xml.Linq;

namespace Project.Domain.ValueObjects;
public record SocialMedia
{
    public string Link { get; private set; } = default!;
    public string Title { get; private set; } = default!;

    private SocialMedia(string link, string title)
    {
        Link = link;
        Title = title;
    }

    public static Result<SocialMedia> Create(string link, string title)
    {
        if (string.IsNullOrWhiteSpace(link))
        {
            return Result.Failure<SocialMedia>("Link to photo cannot be empty");
        }

        if (string.IsNullOrWhiteSpace(title))
        {
            return Result.Failure<SocialMedia>("Title to photo cannot be empty");
        }

        return new SocialMedia(link, title);
    }
}