namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface ISemesterReader
    {
        Task<Semester?> FindByIdAsync(Guid id, CancellationToken ct = default);
        Task<IEnumerable<Semester>> GetAllAsync(CancellationToken ct = default);
        Task<Semester?> FindBySemesterCodeAsync(string semesterCode, CancellationToken ct = default);
        Task<bool> SemesterCodeExistsAsync(string semesterCode, CancellationToken ct = default);
        Task<bool> SemesterCodeExistsExcludingIdAsync(string semesterCode, Guid excludeId, CancellationToken ct = default);
    }
}
