namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface IMajorReader
  {
   Task<Major?> FindByIdAsync(Guid id, CancellationToken ct = default);
      Task<IEnumerable<Major>> GetAllAsync(CancellationToken ct = default);
   Task<IEnumerable<Major>> GetByFacultyIdAsync(Guid facultyId, CancellationToken ct = default);
   Task<bool> MajorNameExistsAsync(string majorName, Guid facultyId, CancellationToken ct = default);
   Task<bool> MajorNameExistsExcludingIdAsync(string majorName, Guid facultyId, Guid excludeId, CancellationToken ct = default);
    }
}
