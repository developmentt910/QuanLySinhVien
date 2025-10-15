using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Entities
{
    public sealed class GradeItem
    {
        public string SemesterCode { get; set; } = "";
        public string CourseCode { get; set; } = "";
        public string CourseTitle { get; set; } = "";
        public int Credits { get; set; }
        public decimal? Midterm { get; set; }
        public decimal? Final { get; set; }
        public decimal? Other { get; set; }
        public decimal? FinalNumeric { get; set; }
        public string? LetterGrade { get; set; }
        public bool? Passed { get; set; }
    }
}
