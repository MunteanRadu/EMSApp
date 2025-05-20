namespace EMSApp.Api;

public class BreakSessionDto
{
    public string Id { get; init; } = null!;
    public string PunchRecordId { get; init; } = null!;
    public TimeOnly StartTime { get; init; }
    public TimeOnly? EndTime { get; init; }
    public TimeSpan? Duration { get; init; }
}
