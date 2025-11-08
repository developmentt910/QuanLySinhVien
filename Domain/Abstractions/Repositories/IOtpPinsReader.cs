
namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface IOtpPinsReader
    {
        Task<(long Id, DateTime ExpiresAtUtc)?>
            GetLastActiveAsync(Guid userId, string purpose, CancellationToken ct = default);
    }
}
