using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Entities
{
    public sealed class ScheduleSlot
    {
        public string DayOfWeek { get; set; } = ""; 
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public string Room { get; set; } = "";
        public string Campus { get; set; } = "";
    }
}
