using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Applications.Dtos
{
    public sealed class StudentDto
    {
        public Guid Id { get; set; }
        public string StudentCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string? Gender { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? PhotoPath { get; set; }
        public byte[]? Photo { get; set; }

        public int? ClassId { get; set; }
        public string? ClassName { get; set; }
        public int? MajorId { get; set; }
        public string? MajorName { get; set; }
        public int? SpecializationId { get; set; }
        public short? CohortYear { get; set; }

        public string Email { get; set; } = string.Empty;
        public bool IsLocked { get; set; }
    }
}
