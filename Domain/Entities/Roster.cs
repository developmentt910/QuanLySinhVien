using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Entities
{
    public sealed class Roster
    {
        public Guid Id { get; init; }
        public string StudentCode { get; init; } = "";
        public string EmailSchool { get; init; } = "";
        public string? FullName { get; init; }
        public bool IsUsed { get; init; }

        public int? ClassId { get; set; }
        public int? MajorId { get; set; }
        public int? SpecializationId { get; set; }
        public short? CohortYear { get; set; }

        public DateTime? ExpiresAtUtc { get; init; }
        public DateTime CreatedAtUtc { get; init; }
    }
}
