namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface ISemesterWriter
    {
     Task<Guid> CreateAsync(Semester semester, CancellationToken ct = default);
      Task UpdateAsync(Semester semester, CancellationToken ct = default);
 Task DeleteAsync(Guid id, CancellationToken ct = default);
    }
}
