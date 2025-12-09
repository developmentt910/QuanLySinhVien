using System;
using System.Threading;
using System.Threading.Tasks;
using StudentCourseManagement.Domain.Entities;

namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface IFacultyWriter
    {
        Task<string> CreateAsync(Faculty faculty, CancellationToken ct = default);
        Task UpdateAsync(Faculty faculty, CancellationToken ct = default);
        Task DeleteAsync(string facultyCode, CancellationToken ct = default);
    }

}
