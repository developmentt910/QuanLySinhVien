namespace StudentCourseManagement.Domain.Entities
{
    public class Student
    {
        public string? StudentId { get; set; }
        public string? FullName { get; set; }

        public string? Faculty { get; set; }   // Khoa
        public string? Major { get; set; }
        public string? Specialization { get; set; }
        public string? ClassName { get; set; }

        public string? Gender { get; set; }

        // ✅ CHỐT DÙNG Phone
        public string? Phone { get; set; }

        public string? CCCD { get; set; }

        // ✅ CHỐT DÙNG Email
        public string? Email { get; set; }

        public string? Address { get; set; }
        public string? Status { get; set; }
        public string? Year { get; set; }

        public string? PasswordHash { get; set; }
    }
}
