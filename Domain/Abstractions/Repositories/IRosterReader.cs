

namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface IRosterReader
    {
        //Task<Roster?> FindByIdAsync(Guid id, CancellationToken ct = default);
        //Task<Roster?> FindBySchoolEmailAsync(string emailSchool, CancellationToken ct = default);
        //Task<bool> IsActiveAsync(Guid id, DateTime utcNow, CancellationToken ct = default);
        //Task<IReadOnlyList<Roster>> SearchAsync(string? keyword, int skip, int take, CancellationToken ct = default);
        //Task<int> CountActiveAsync(DateTime utcNow, CancellationToken ct = default);


        Task<Roster?> FindByStudentCodeAsync(string studentCode, CancellationToken ct = default);
        Task<Roster?> FindByPrivilegeCodeAsync(string privilegeCode, CancellationToken ct = default);


    }
}
