using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Entities
{
    public class ResultSubjectDto
    {
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int Credits { get; set; }
        public Guid ClassId { get; set; }
        public string ClassName { get; set; }
    }
}
