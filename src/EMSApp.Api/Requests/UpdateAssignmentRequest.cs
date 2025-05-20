using EMSApp.Domain.Entities;

namespace EMSApp.Api;

public record class UpdateAssignmentRequest
{
    public string? Title { get; init; }
    public string? Description { get; init; }
    public DateTime? DueDate { get; init; }
    public string? AssignedToId {  get; init; }
    public AssignmentStatus? Status { get; init; }
}
