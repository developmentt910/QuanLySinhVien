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
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid SemesterId { get; set; }
        public string SemesterName { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
        public DateTime EvaluatedAtUtc { get; set; }


    public string RankName
        {
            get
            {
                if (Score >= 90) return "Xuất sắc";
                if (Score >= 80) return "Tốt";
                if (Score >= 65) return "Khá";
                if (Score >= 50) return "Trung bình";
                return "Yếu";
            }
        }

    }
}
