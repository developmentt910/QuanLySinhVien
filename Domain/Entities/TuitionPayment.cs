using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Entities
{
    public sealed class TuitionPayment
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public string Method { get; set; } = "cash";
        public DateTime PaidAtUtc { get; set; }
        public string? RefCode { get; set; }
        public string Status { get; set; } = "success";
    }
}
