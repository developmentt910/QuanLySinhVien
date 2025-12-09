using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StudentCourseManagement.Domain.Entities;

namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface IFacultyReader
    {
        Task<Faculty?> FindByCodeAsync(string code, CancellationToken ct = default);
        Task<IEnumerable<Faculty>> GetAllAsync(CancellationToken ct = default);

        Task<bool> FacultyNameExistsAsync(string name, CancellationToken ct = default);
        Task<bool> FacultyNameExistsExcludingCodeAsync(string name, string code, CancellationToken ct = default);
    }

}
