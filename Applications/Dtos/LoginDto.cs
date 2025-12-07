using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Applications.Dtos
{
    public class LoginDto
    {
        public string? PrivilegeCode { get; set; }
        public string Password { get; set; } = null!;
        
        public string CaptchaToken { get; set; } = null!;
        public string CaptchaInput { get; set; } = null!;


    }
}
