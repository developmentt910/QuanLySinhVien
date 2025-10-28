using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Entities
{
    public sealed class AuditLogEntry
    {
        public long Id { get; init; }
        public Guid? UserId { get; init; }
        public string Action { get; init; } = string.Empty;  // hd cu the: login_success, login_failed, password_changed

        public string? Detail { get; init; } // json/text, rong
        public DateTime CreatedAtUtc { get; init; } = DateTime.UtcNow;

    }
}
