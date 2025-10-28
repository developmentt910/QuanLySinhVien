using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface IAuditLogsWriter
    {
        Task WriteAsync (AuditLogEntry entry, CancellationToken ct = default);
        Task WriteManyAsync(IEnumerable<AuditLogEntry> entries, CancellationToken ct = default);

    }
}
