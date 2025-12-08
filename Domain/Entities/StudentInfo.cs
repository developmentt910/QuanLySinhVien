using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Entities
{
    public class StudentInfo
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string? ClassId { get; set; }
        public string? ClassName { get; set; }
        public string? MajorName { get; set; }
        public string? SpecializationName { get; set; }
        public string StudentCode;

        
                    public Guid SpecializationId { get; set; }

    }

}
