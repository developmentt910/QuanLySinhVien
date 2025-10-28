
namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface IOtpPinsReader
    {
        Task<(long Id, byte[] CodeHash, byte[] Salt, DateTime ExpiresAtUtc, int AttemptCount)?>
            GetLastActiveAsync(Guid userId, string purpose, CancellationToken ct = default);
    }
}
