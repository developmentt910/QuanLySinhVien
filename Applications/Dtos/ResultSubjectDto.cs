using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Applications.Dtos
{
    public class ResultSubjectDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid SubjectId { get; set; }

        public float? Midterm { get; set; }
        public float? Final { get; set; }
        public float? Other { get; set; }

        public float? FinalNumeric { get; set; }
        public string LetterGrade { get; set; }
        public bool? Passed { get; set; }

        public DateTime? UpdatedAtUtc { get; set; }
    }
}
