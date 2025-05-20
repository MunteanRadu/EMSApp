namespace EMSApp.Api;

public record AssignmentDto
{
    public string Id { get; init; } = null!;
    public string Title { get; init; } = null!;
    public string Description { get; init; } = null!;
    public DateTime DueDate { get; init; }
    public string AssignedToId { get; init; } = null!;
    public string Status { get; init; } = null!;
}
