using EMSApp.Domain;

namespace EMSApp.Api;

public record CreateLeaveRequestRequest(
    string UserId,
    LeaveType Type,
    DateOnly StartDate,
    DateOnly EndDate,
    string Reason
);
