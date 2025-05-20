namespace EMSApp.Api;

public class ScheduleDto
{
    public string Id { get; init; } = null!;
    public string DepartmentId { get; init; } = null!;
    public string ManagerId { get; init; } = null!;
    public DayOfWeek Day { get; init; }
    public TimeOnly StartTime { get; init; }
    public TimeOnly EndTime { get; init; }
    public bool IsWorkingDay { get; init; }
}
