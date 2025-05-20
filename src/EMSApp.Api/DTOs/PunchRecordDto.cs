namespace EMSApp.Api;

public class PunchRecordDto
{
    public string Id { get; init; } = null!;
    public string UserId { get; init; } = null!;
    public DateOnly Date { get; init; }
    public TimeOnly TimeIn { get; init; }
    public TimeOnly? TimeOut { get; init; }
    public TimeSpan? TotalHours { get; init; }
    public List<BreakSessionDto> BreakSessions { get; init; } = null!;
}
