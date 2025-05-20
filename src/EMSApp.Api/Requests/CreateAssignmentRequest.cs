namespace EMSApp.Api;

public class CreateAssignmentRequest
{
    public string Title { get; init; } = null!;
    public string Description { get; init; } = null!;
    public DateTime DueDate { get; init; }
    public string AssignedToId { get; init; } = null!;
}
