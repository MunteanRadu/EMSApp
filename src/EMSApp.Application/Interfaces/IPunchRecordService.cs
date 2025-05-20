using EMSApp.Domain;

namespace EMSApp.Application;

public interface IPunchRecordService
{
    Task<PunchRecord> CreateAsync(string userId, DateOnly date, TimeOnly time, CancellationToken ct);
    Task<PunchRecord?> GetByIdAsync(string id, CancellationToken ct);
    Task<IReadOnlyList<PunchRecord>> ListByUserAsync(string userId, CancellationToken ct);
    Task UpdateAsync(PunchRecord record, CancellationToken ct);
    Task DeleteAsync(string id, CancellationToken ct);
    Task<IReadOnlyList<PunchRecord>> GetAllAsync(CancellationToken ct);
}
