using EMSApp.Domain;

namespace EMSApp.Application;

public interface IBreakSessionService
{
    Task<BreakSession> CreateAsync(string punchRecordId, TimeOnly start, CancellationToken ct);
    Task<BreakSession?> GetByIdAsync(string id, CancellationToken ct);
    Task<IReadOnlyList<BreakSession>> ListByPunchRecordAsync(string punchRecordId, CancellationToken ct);
    Task UpdateAsync(BreakSession newBreakSession, CancellationToken ct);
    Task DeleteAsync(string id, CancellationToken ct);
    Task<IReadOnlyList<BreakSession>> GetAllAsync(CancellationToken ct);
}
