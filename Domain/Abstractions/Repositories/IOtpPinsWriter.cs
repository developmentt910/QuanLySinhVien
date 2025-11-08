

namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface IOtpPinsWriter

        //byte[] codeHash, byte[] Salt,
    {
        Task<long> CreateAsync(Guid userId, string purpose,  DateTime ExpiresAtUtc, CancellationToken ct = default);
        //Task ConsumeAsync(long id, CancellationToken ct = default);
        //Task IncrementAttemptAsync(long id, CancellationToken ct = default); 
    }
}
