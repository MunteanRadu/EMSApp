namespace EMSApp.Api;

public record CreateBreakSessionRequest(
    string PunchRecordId,
    TimeOnly StartTime
);
