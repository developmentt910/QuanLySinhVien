using System;

namespace StudentCourseManagement.Domain.Entities
{
    public class Student
    {
        // =====================
        // ✅ KHÓA & ĐỊNH DANH
        // =====================
        public string StudentId { get; set; }   // StudentCode trong DB

        // =====================
        // ✅ THÔNG TIN CƠ BẢN
        // =====================
        public string FullName { get; set; }
        public string Gender { get; set; }
        public byte[] ProfileImage { get; set; }
        // =====================
        // ✅ QUAN HỆ HỌC TẬP
        // =====================
        public Guid? ClassId { get; set; }
        public Guid? MajorId { get; set; }
        public Guid? SpecializationId { get; set; }

        // =====================
        // ✅ TÊN HIỂN THỊ (JOIN)
        // =====================
        public string Faculty { get; set; }
        public string Major { get; set; }
        public string Specialization { get; set; }
        public string ClassName { get; set; }

        // =====================
        // ✅ LIÊN HỆ
        // =====================
        public string Phone { get; set; }
        public string CCCD { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        // =====================
        // ✅ TRẠNG THÁI
        // =====================
        public string Status { get; set; }   // Đang học | Đã tốt nghiệp | Bảo lưu
        public string Year { get; set; }     // CohortYear

        // =====================
        // ✅ BẢO MẬT
        // =====================
        public string PasswordHash { get; set; }
    }
}
