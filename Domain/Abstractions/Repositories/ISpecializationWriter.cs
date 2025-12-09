namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface ISpecializationWriter
    {
      Task<Guid> CreateAsync(Specialization specialization, CancellationToken ct = default);
   Task UpdateAsync(Specialization specialization, CancellationToken ct = default);
        Task DeleteAsync(Guid id, CancellationToken ct = default);
    }
}
