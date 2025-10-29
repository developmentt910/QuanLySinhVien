using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Entities
{
    public sealed class Specialization
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string SpecializationName { get; set; } = null!;

        // Foreign key
        public Guid MajorId { get; set; }
        public Major Major { get; set; } = null!;

        // Navigation property
        public ICollection<Class> Classes { get; set; } = new List<Class>();
    }
}
