using EMSApp.Domain;

namespace EMSApp.Api;

public class LeaveRequestDto
{
    public string Id { get; init; } = null!;
    public string UserId { get; init; } = null!;
    public LeaveType Type { get; init; }
    public DateOnly StartDate { get; init; }
    public DateOnly EndDate { get; init; }
    public string Reason { get; init; } = null!;
    public LeaveStatus Status { get; init; }
    public string? ManagerId { get; init; }
    public DateTimeOffset? RequestedAt { get; init; }
}
