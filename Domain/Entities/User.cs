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
        public string? StudentCodeNullable { get; set; }
        public string? StudentCode { get => StudentCodeNullable; set => StudentCodeNullable = value; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty ;
        public string? Phone { get; set; }
        public string? Cccd { get; set; }
        public string Role { get; set; } = "student";
        public string PasswordHash { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;
        public int Iterations { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsLocked { get; set; }
    }
}
