

namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface IRosterReader
    {
        Task<Roster?> FindByIdAsync(Guid id, CancellationToken ct = default);
    

        Task<bool> PrivilegeCodeExistsAsync(string privilegeCode, CancellationToken ct = default);
        Task<Roster?> FindByPrivilegeCode(string v, CancellationToken ct = default);
    }
}
