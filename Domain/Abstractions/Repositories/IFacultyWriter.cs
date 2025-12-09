namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface IFacultyWriter
    {
   Task<Guid> CreateAsync(Faculty faculty, CancellationToken ct = default);
 Task UpdateAsync(Faculty faculty, CancellationToken ct = default);
  Task DeleteAsync(Guid id, CancellationToken ct = default);
    }
}
