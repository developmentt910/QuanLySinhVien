using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Entities
{
    /// <summary>
    /// Đại diện cho thông tin một sinh viên trong hệ thống.
    /// </summary>
    public class Student
    {
        public string? StudentId { get; set; }
        public string? FullName { get; set; }
        public string? Major { get; set; }
        public string? Specialization { get; set; }
        public string? ClassName { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? CCCD { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Status { get; set; }
        public string Year { get; set; } = string.Empty;
    }
}

