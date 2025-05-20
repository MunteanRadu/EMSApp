namespace EMSApp.Api;

public record UserDto
{
    public string Id { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string Username { get; init; } = null!;
    public string DepartmentId { get; init; } = null!;
}
