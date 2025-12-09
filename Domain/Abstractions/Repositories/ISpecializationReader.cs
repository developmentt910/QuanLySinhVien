namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface ISpecializationReader
    {
        Task<Specialization?> FindByIdAsync(Guid id, CancellationToken ct = default);
        Task<IEnumerable<Specialization>> GetAllAsync(CancellationToken ct = default);
        Task<IEnumerable<Specialization>> GetByMajorIdAsync(Guid majorId, CancellationToken ct = default);
        Task<bool> SpecializationNameExistsAsync(string name, Guid majorId, CancellationToken ct = default);
        Task<bool> SpecializationNameExistsExcludingIdAsync(string name, Guid majorId, Guid excludeId, CancellationToken ct = default);
    }
}
