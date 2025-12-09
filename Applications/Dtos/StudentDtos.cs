using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Applications.Dtos
{
    public class StudentDtos
    {
        public string StudentCode { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int? CohortYear { get; set; }

        public string ClassName { get; set; }
        public string MajorName { get; set; }
        public string SpecializationName { get; set; }
        public string FacultyName { get; set; }

        public string CCCD { get; set; }
        public string Phone164 { get; set; }

        public Guid ClassId { get; set; }
        public Guid MajorId { get; set; }
        public Guid SpecializationId { get; set; }
        public Guid FacultyId { get; set; }

        public bool IsUsed { get; set; }

        public byte[] ProfileImage { get; set; }

        public Guid Id { get; set; }
        public string PasswordHash { get; set; }
    }
}
