using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentCourseManagement.Domain.Entities
{
    public sealed class GradeAggregate
    {
        public string SemesterCode { get; set; } = "";
        public IReadOnlyList<GradeItem> Items { get; set; } = Array.Empty<GradeItem>();
        public decimal GPA { get; set; }          
        public int ConductScore { get; set; }    
        public int CreditsAttempted { get; set; }
        public int CreditsEarned { get; set; }
    }
}
