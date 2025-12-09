using System;

namespace StudentCourseManagement.Applications.Students.Dtos
{
    public class StudentDto
    {
        // =====================
        // ✅ KHÓA & ĐỊNH DANH
        // =====================
        public string StudentId { get; set; }

        // =====================
        // ✅ THÔNG TIN CƠ BẢN
        // =====================
        public string FullName { get; set; }
        public string Gender { get; set; }

        // =====================
        // ✅ ID KHÓA NGOẠI (LƯU DB)
        // =====================
        public Guid? FacultyId { get; set; }       // ✅ THÊM DÒNG NÀY
        public Guid? MajorId { get; set; }
        public Guid? SpecializationId { get; set; }
        public Guid? ClassId { get; set; }
        

        // =====================
        // ✅ TÊN HIỂN THỊ (FORM)
        // =====================
        public string Faculty { get; set; }
        public string Major { get; set; }
        public string Specialization { get; set; }
        public string ClassName { get; set; }
        public byte[] ProfileImage { get; set; }

        // =====================
        // ✅ LIÊN HỆ
        // =====================
        public string Phone { get; set; }
        public string CCCD { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        // =====================
        // ✅ TRẠNG THÁI
        // =====================
        public string Status { get; set; }
        public string Year { get; set; }

        // =====================
        // ✅ MẬT KHẨU (PLAINTEXT)
        // =====================
        public string Password { get; set; }
    }
}
