using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Entities
{
    public sealed class SectionListItem
    {
        public Guid SectionId { get; set; }
        public Guid CourseId { get; set; }
        public Guid SemesterId { get; set; }
        public string CourseCode { get; set; } = "";
        public string CourseTitle { get; set; } = "";
        public int Credits { get; set; }
        public string SectionCode { get; set; } = "";
        public string Lecturer { get; set; } = "";
        public int Capacity { get; set; }
        public int CurrentSize { get; set; }
        public string? Room { get; set; }
    }
}
