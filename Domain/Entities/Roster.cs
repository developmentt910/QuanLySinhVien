

namespace StudentCourseManagement.Domain.Entities
{
    public sealed class Roster
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string? CCCD { get; set; }
        public string? Phone164 { get; set; }
        public string Role { get; set; } = "user";
        public string? Gender { get; set; }
        public string? Address { get; set; }

        public string? EmailSchool;
        public string? PrivilegeCode { get; set; }

        public bool IsUsed;

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;

        public byte[]? ProfileImage { get; set; }

    }
}