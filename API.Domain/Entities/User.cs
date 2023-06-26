namespace API.Domain.Entities;

public class User : BaseEntity
{
    public string Document { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}