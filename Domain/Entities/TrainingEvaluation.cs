using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Entities
{
    // Trong thư mục: Domain/Entities
    public class TrainingEvaluation
    {
        // Id này có thể là int nếu trong DB là Identity, hoặc Guid nếu dùng Guid
        public Guid Id { get; set; }
        public Guid UserId { get; set; } // Liên kết đến Users.Id
        public Guid SemesterId { get; set; }
        public int? Score { get; set; }
        public string? Comment { get; set; }
        public DateTime EvaluatedAtUtc { get; set; }
        public string ClassName { get; set; }
        public string FacultyName { get; set; }
        public string? SemesterName { get; set; }   // tên học kỳ
        public string Rank { get; set; }           // xếp loại (Xuất sắc / Tốt / ...)
    }

    // Thêm các Entity liên quan nếu cần
    // public class Roster { public Guid Id { get; set; } public string StudentCode { get; set; } ... }
}
