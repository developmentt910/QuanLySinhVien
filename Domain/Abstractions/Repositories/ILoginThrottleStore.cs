using System;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface ILoginThrottleStore
    {
        Task<int> IncrementAndGetAsync(string scope, byte[] keyHash, DateTime windowStart, CancellationToken ct = default);
        Task ResetScopeAsync(string scope, byte[] keyHash, CancellationToken ct = default);
    }
}
