using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Entities
{
    public sealed class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; } = null!;
        public string EmailNormalized { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string? CCCD { get; set; }       // Số căn cước
        public string? PhoneE164 { get; set; }  // +84xxxxxxxxx
        public string Role { get; set; } = "user";
        public string? Gender { get; set; }     
        public string? Address { get; set; }
        // Foreign key
        public Guid? RosterId { get; set; }
        public Roster? Roster { get; set; }

        public string? StudentCode { get; set; }
        public string? PrivilegeCode { get; set; }
        public Guid? ClassId { get; set; }
        public Guid? MajorId { get; set; }
        public Guid? SpecializationId { get; set; }
        public int? CohortYear { get; set; }

        public bool EmailVerified { get; set; } = false;
        public bool IsLocked { get; set; } = false;

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
