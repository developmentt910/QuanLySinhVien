using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Entities
{
    public sealed class Section
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string CourseCode { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public int Credits { get; set; }
        public string SectionCode { get; set; } = string.Empty;
        public string Instructor { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public int CurrentSize { get; set; }
        public string SemesterCode { get; set; } = string.Empty;
        public IEnumerable<ScheduleSlot> Schedules { get; set; } = Array.Empty<ScheduleSlot>();
        public IEnumerable<ExamSlot> Exams { get; set; } = Array.Empty<ExamSlot>();
    }
}
