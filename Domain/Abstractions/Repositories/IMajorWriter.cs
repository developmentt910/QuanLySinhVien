namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface IMajorWriter
    {
   Task<Guid> CreateAsync(Major major, CancellationToken ct = default);
   Task UpdateAsync(Major major, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
    }
}
