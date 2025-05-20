using EMSApp.Application;
using EMSApp.Domain;

namespace EMSApp.Infrastructure;

public class PunchRecordService : IPunchRecordService
{
    private readonly IPunchRecordRepository _repo;
    public PunchRecordService(IPunchRecordRepository repo)
    {
        _repo = repo;
    }

    public async Task<PunchRecord> CreateAsync(string userId, DateOnly date, TimeOnly time, CancellationToken ct)
    {
        var punchRecord = new PunchRecord(userId, date, time);
        await _repo.CreateAsync(punchRecord, ct);
        return punchRecord;
    }

    public Task<PunchRecord?> GetByIdAsync(string id, CancellationToken ct)
    {
        return _repo.GetByIdAsync(id, ct);
    }

    public Task<IReadOnlyList<PunchRecord>> ListByUserAsync(string userId, CancellationToken ct)
    {
        return _repo.ListByUserAsync(userId, ct);
    }

    public Task UpdateAsync(PunchRecord record, CancellationToken ct)
    {
        return _repo.UpdateAsync(record, false, ct);
    }

    public Task DeleteAsync(string id, CancellationToken ct)
    {
        return _repo.DeleteAsync(id, ct);
    }

    public Task<IReadOnlyList<PunchRecord>> GetAllAsync(CancellationToken ct)
    {
        return _repo.GetAllAsync(ct);
    }
}
