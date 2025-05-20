using EMSApp.Application;
using EMSApp.Domain;

namespace EMSApp.Infrastructure;

public class BreakSessionService : IBreakSessionService
{
    private readonly IBreakSessionRepository _repo;
    public BreakSessionService(IBreakSessionRepository repo)
    {
        _repo = repo;
    }

    public async Task<BreakSession> CreateAsync(string punchRecordId, TimeOnly start, CancellationToken ct)
    {
        var breakSession = new BreakSession(punchRecordId, start);
        await _repo.CreateAsync(breakSession, ct);
        return breakSession;
    }

    public Task<BreakSession?> GetByIdAsync(string id, CancellationToken ct)
    {
        return _repo.GetByIdAsync(id, ct);
    }

    public Task<IReadOnlyList<BreakSession>> ListByPunchRecordAsync(string punchRecordId, CancellationToken ct)
    {
        return _repo.ListByPunchRecordAsync(punchRecordId, ct);
    }

    public Task UpdateAsync(BreakSession newBreakSession, CancellationToken ct)
    {
        return _repo.UpdateAsync(newBreakSession, false, ct);
    }

    public Task DeleteAsync(string id, CancellationToken ct)
    {
        return _repo.DeleteAsync(id, ct);
    }

    public Task<IReadOnlyList<BreakSession>> GetAllAsync(CancellationToken ct)
    {
        return _repo.GetAllAsync(ct);
    }
}
