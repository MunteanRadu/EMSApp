using EMSApp.Domain;

namespace EMSApp.Api;

public record class UpdateLeaveRequestRequest
{
    public LeaveType? Type { get; init; }
    public DateOnly? StartDate { get; init; }
    public DateOnly? EndDate { get; init; }
    public string? Reason { get; init; }
}
