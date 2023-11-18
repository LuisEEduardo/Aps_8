namespace Aps.Api.Model;

public record Information
{
    public static Information CreateInformation(string title, string description, string local, string image)
    {
        Information information = new()
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.Now,
            UpdateAt = null,
            Title = title,
            Description = description,
            Local = local,
            Image = image
        };

        return information;
    }

    public Information()
    {
    }

    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdateAt { get; private set; }
    public String? Title { get; private set; }
    public String? Description { get; private set; }
    public String? Local { get; private set; }
    public String? Image { get; private set; }
}



