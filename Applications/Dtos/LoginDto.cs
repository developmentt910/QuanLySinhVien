using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Applications.Dtos
{
    public sealed class LoginDto
    {
        public string StudentCodeOrEmail { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? CaptchaToken { get; set; }
        public string? CaptchaInput { get; set; }
    }
}
