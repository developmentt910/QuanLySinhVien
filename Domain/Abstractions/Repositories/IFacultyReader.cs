namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface IFacultyReader
  {
Task<Faculty?> FindByIdAsync(Guid id, CancellationToken ct = default);
     Task<IEnumerable<Faculty>> GetAllAsync(CancellationToken ct = default);
  Task<bool> FacultyNameExistsAsync(string facultyName, CancellationToken ct = default);
   Task<bool> FacultyNameExistsExcludingIdAsync(string facultyName, Guid excludeId, CancellationToken ct = default);
    }
}

