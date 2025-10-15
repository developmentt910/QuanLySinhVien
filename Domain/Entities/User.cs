using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Entities
{
    public sealed class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;        // normalized
        public string EmailNormalized { get; set; } = string.Empty; // lower-case
        public string PasswordHash { get; set; } = string.Empty;    // $pbkdf2-sha256$...
        public string CCCD { get; set; } = string.Empty;            // 12 digits
        public string? PhoneE164 { get; set; }                      // +84...
        public string Role { get; set; } = "user";                  // user|admin
        public Guid? RosterId { get; set; }                         // link đến Roster
        public string? StudentCode { get; set; }                    // MSV
        public bool EmailVerified { get; set; }
        public bool IsLocked { get; set; }
    }
}
