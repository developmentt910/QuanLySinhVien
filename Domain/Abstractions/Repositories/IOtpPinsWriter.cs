

namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface IOtpPinsWriter
    {
        Task<long> CreateAsync(Guid userId, string purpose, byte[] codeHash, byte[] Salt, DateTime ExpiresAtUtc, CancellationToken ct = default);
        Task ConsumeAsync(long id, CancellationToken ct = default);
        Task IncrementAttemptAsync(long id, CancellationToken ct = default); 
    }
}
