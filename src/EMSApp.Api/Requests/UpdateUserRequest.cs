using EMSApp.Domain.Entities;

namespace EMSApp.Api;

public class UpdateUserRequest
{
    public string? Email { get; init; }
    public string? Username { get; init; }
    public string? PasswordHash { get; init; }
    public string? DepartmentId { get; init; }
    public UserProfileDto? Profile { get; init; }
    public UserRole? Role { get; init; }
}
