using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Entities
{
    public sealed class Enrollment
    {
        public long EnrollmentId { get; set; }
        public Guid UserId { get; set; }
        public int CourseId { get; set; }
        public string CourseCode { get; set; } = string.Empty;
        public string CourseTitle { get; set; } = string.Empty;
        public int Credits { get; set; }
        public int SemesterId { get; set; }
        public string SemesterCode { get; set; } = string.Empty;

        public long RegistrationId { get; set; }
        public int SectionId { get; set; }
        public string SectionCode { get; set; } = string.Empty;
        public string Status { get; set; } = "enrolled"; // enrolled|dropped
        public DateTime RegisteredAtUtc { get; set; }
    }
}
