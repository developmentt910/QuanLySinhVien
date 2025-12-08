using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Entities
{
    public class Subject
    {
        public Guid Id { get; set; } //
        public string? SubjectCode { get; set; } //
        public string? SubjectName { get; set; } //
        public int Credit { get; set; } //
    }
}
