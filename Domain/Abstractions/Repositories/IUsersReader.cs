

namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface IUsersReader
    {
        Task<User?> FindByEmailAsync(string emailNormalized, CancellationToken ct = default);
        Task<User?> FindByIdAsync(Guid id, CancellationToken ct = default);

        Task<bool> EmailExistsAsync(string email, CancellationToken ct = default);
        Task<bool> CccdExistsAsync(string cccd, CancellationToken ct = default);




        Task<User?> FindByStudentCode(string studentCode, CancellationToken ct = default);
        Task<bool> StudentCodeExistsAsync(string studentCode, CancellationToken ct = default);
        Task<bool> PrivilegeCodeExistsAsync(string privilegeCode, CancellationToken ct = default);
        Task<User?> FindByPrivilegeCode(string v, CancellationToken ct = default);
    }
}
