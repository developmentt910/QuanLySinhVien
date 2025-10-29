using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Entities
{
    public sealed class Faculty
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FacultyName { get; set; } = null!;

        // Navigation property
        public ICollection<Major> Majors { get; set; } = new List<Major>();
    }
}
