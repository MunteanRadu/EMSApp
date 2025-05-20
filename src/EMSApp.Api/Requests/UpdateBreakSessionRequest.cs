namespace EMSApp.Api;

public record class UpdateBreakSessionRequest
{
    public TimeOnly? StartTime { get; init; }
    public TimeOnly? EndTime { get; init; }
}
