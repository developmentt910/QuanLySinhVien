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
        public string FullName { get; set; } = string.Empty;        
        public string EmailNormalized { get; set; } = string.Empty; 
        public string PasswordHash { get; set; } = string.Empty;    
        public string CCCD { get; set; } = string.Empty;           
        public string? PhoneE164 { get; set; }                      
        public string Role { get; set; } = "user";                  
        public Guid? RosterId { get; set; }                       
        public string? StudentCode { get; set; }                   
        public bool EmailVerified { get; set; }
        public bool IsLocked { get; set; }

        public int? ClassId { get; set; }
        public int? MajorId { get; set; }
        public int? SpecializationId { get; set; }
        public short? CohortYear { get; set; }

        public DateTime? CreatedAtUtc { get; set; }
        public DateTime? UpdatedAtUtc { get; set; }
    }
}
