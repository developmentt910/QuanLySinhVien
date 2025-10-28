using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface IPrivilegesReader
    {
        Task<(
            Guid Id,
            byte[] CodeHash,
            byte[] salt,
            DateTime? ExpiresAtUtc,
            bool IsUsed
           )?> GetLastestAsync();
    }
}
