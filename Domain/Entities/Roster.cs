using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Entities
{
    public sealed class Roster
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string StudentCode { get; set; } = null!;
        public string? PrivilegeCode { get; set; }
        public string EmailSchool { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? Gender { get; set; }           // Nam / Nữ / Khác
        public string? Address { get; set; }
        public string? Role { get; set; }
        public bool IsUsed { get; set; } = false;
        public DateTime? ExpiresAtUtc { get; set; }
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        // Foreign keys
        public Guid? ClassId { get; set; }
        public Class? Class { get; set; }

        public Guid? MajorId { get; set; }
        public Major? Major { get; set; }

        public Guid? SpecializationId { get; set; }
        public Specialization? Specialization { get; set; }

        public int? CohortYear { get; set; }   // Niên khóa

     
    }
}
