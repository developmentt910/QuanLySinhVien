using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Entities
{
    public sealed class Class
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ClassCode { get; set; } = null!;
        public string ClassName { get; set; } = null!;

        // Foreign keys
        public Guid MajorId { get; set; }
        public Major Major { get; set; } = null!;

        public Guid SpecializationId { get; set; }
        public Specialization Specialization { get; set; } = null!;
    }
}
