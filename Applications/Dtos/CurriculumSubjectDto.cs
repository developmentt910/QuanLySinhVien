using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Applications.Dtos
{
    using System;

    namespace Dtos
    {
        public class CurriculumSubjectDto
        {
            public Guid SubjectId { get; set; }
            public string SubjectName { get; set; }
            public string ClassName { get; set; }
            public int Credits { get; set; }
        }
    }

}
