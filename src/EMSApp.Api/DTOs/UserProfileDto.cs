namespace EMSApp.Api;

public record UserProfileDto
{
    public string Id { get; init; } = null!;
    public string Name { get; init; } = null!;
    public string JobTitle { get; init; } = null!;
    public int Age { get; init; }
    public string Phone { get; init; } = null!;
    public string Address { get; init; } = null!;
    public string EmergencyContact { get; init; } = null!;
}
