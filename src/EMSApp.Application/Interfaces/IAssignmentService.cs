using EMSApp.Domain;
using EMSApp.Domain.Entities;

namespace EMSApp.Application;

public interface IAssignmentService
{
    Task<Assignment> CreateAsync(string title, string description, DateTime dueDate, string assignedTo, CancellationToken ct);
    Task<Assignment?> GetByIdAsync(string id, CancellationToken ct);
    Task<IReadOnlyList<Assignment>> ListByAsigneeAsync(string userId, CancellationToken ct);
    Task<IReadOnlyList<Assignment>> ListByStatusAsync(AssignmentStatus status, CancellationToken ct);
    Task<IReadOnlyList<Assignment>> ListByOverdueAsync(DateTime asOf, CancellationToken ct);
    Task UpdateAsync(Assignment assignment, CancellationToken ct);
    Task DeleteAsync(string id, CancellationToken ct);
    Task<IReadOnlyList<Assignment>> GetAllAsync(CancellationToken ct);
}
