using EMSApp.Application;
using EMSApp.Domain;
using EMSApp.Domain.Entities;

namespace EMSApp.Infrastructure;

public class AssignmentService : IAssignmentService
{
    private readonly IAssignmentRepository _repo;
    public AssignmentService(IAssignmentRepository repo)
    {
        _repo = repo;
    }

    public async Task<Assignment> CreateAsync(string title, string description, DateTime dueDate, string assignedTo, CancellationToken ct)
    {
        var assignment = new Assignment(title, description, dueDate, assignedTo);
        await _repo.CreateAsync(assignment, ct);
        return assignment;
    }

    public Task<Assignment?> GetByIdAsync(string id, CancellationToken ct)
    {
        return _repo.GetByIdAsync(id, ct);
    }

    public Task<IReadOnlyList<Assignment>> ListByAsigneeAsync(string userId, CancellationToken ct)
    {
        return _repo.ListByAssigneeAsync(userId, ct);
    }

    public Task<IReadOnlyList<Assignment>> ListByOverdueAsync(DateTime asOf, CancellationToken ct)
    {
        return _repo.ListOverdueAsync(asOf, ct);
    }

    public Task<IReadOnlyList<Assignment>> ListByStatusAsync(AssignmentStatus status, CancellationToken ct)
    {
        return _repo.ListByStatusAsync(status, ct);
    }

    public Task UpdateAsync(Assignment assignment, CancellationToken ct)
    {
        return _repo.UpdateAsync(assignment, false, ct);
    }

    public Task DeleteAsync(string id, CancellationToken ct)
    {
        return _repo.DeleteAsync(id, ct);
    }

    public Task<IReadOnlyList<Assignment>> GetAllAsync(CancellationToken ct)
    {
        return _repo.GetAllAsync(ct);
    }
}
