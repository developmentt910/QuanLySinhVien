using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Entities
{
    public sealed class CurriculumCourseVm
    {
        public int SemesterOrder { get; set; }
        public string CourseCode { get; set; } = "";
        public string CourseTitle { get; set; } = "";
        public int Credits { get; set; }
        public bool IsRequired { get; set; }
        public bool AlreadyPassed { get; set; }
    }
}
