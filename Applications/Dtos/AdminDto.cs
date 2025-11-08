using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Applications.Dtos
{
    public class AdminInfoDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? CCCD { get; set; }
        public string? Phone { get; set; }
        public string EmailSchool { get; set; } = null!;
        public Image? Avatar { get; set; }
    }
}
