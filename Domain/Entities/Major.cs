using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Entities
{
    public sealed class Major
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string MajorName { get; set; } = null!;

        // Foreign key
        public Guid FacultyId { get; set; }
        public Faculty Faculty { get; set; } = null!;

    }
}
