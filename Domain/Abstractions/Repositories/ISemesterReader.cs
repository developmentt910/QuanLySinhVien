namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface ISemesterReader
 {
        Task<Semester?> FindByIdAsync(Guid id, CancellationToken ct = default);
   Task<IEnumerable<Semester>> GetAllAsync(CancellationToken ct = default);
   Task<IEnumerable<Semester>> GetByMajorIdAsync(Guid majorId, CancellationToken ct = default);
        Task<bool> SemesterNameExistsAsync(string semesterName, Guid majorId, CancellationToken ct = default);
    Task<bool> SemesterNameExistsExcludingIdAsync(string semesterName, Guid majorId, Guid excludeId, CancellationToken ct = default);
        Task<IEnumerable<Semester>> GetActiveSemestersAsync(CancellationToken ct = default);
    }
}
