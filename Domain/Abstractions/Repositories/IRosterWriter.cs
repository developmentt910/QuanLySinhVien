

namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface IRosterWriter
    {
        Task UpdatePasswordHashAsync (Guid id, string passwordHash, CancellationToken ct = default);
       
        Task UpdateUserInfoAsync(Roster u, CancellationToken ct = default);

    }
}
