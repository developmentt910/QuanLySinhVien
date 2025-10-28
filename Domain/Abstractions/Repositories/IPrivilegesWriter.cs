using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface IPrivilegesWriter
    {
        Task MarkUsedAsync(Guid privilegeId);
    }
}
