using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Applications.Dtos
{
    public sealed class RegisterDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string EmailSchool { get; set; } = string.Empty;
        public string CCCD { get; set; } = string.Empty;
        public string Phone164 { get; set; } = string.Empty;
        public string StudentCode { get; set; } = string.Empty;
        public string? PrivilegeCode { get; set; } = string.Empty;
    }
}
