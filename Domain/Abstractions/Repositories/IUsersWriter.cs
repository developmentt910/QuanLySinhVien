

namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface IUsersWriter
    {
        Task<Guid> CreateAsync(User u, CancellationToken ct = default);
        Task UpdatePasswordHashAsync (Guid id, string passwordHash, CancellationToken ct = default);
        Task SetLockedAsync (Guid id, bool locked, CancellationToken ct = default);
        Task LinkRosterUsedAsync(Guid rosterId, CancellationToken ct = default);    
        Task MarkEmailVerifiedAsync(Guid id, DateTime verifiedAtUtc, CancellationToken ct = default);

        //Task UpdateStudentAsync(User u, CancellationToken ct = default);

    }
}
