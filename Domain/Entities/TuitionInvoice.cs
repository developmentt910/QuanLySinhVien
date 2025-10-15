using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Entities
{
    public sealed class TuitionInvoice
    {
        public long Id { get; set; }
        public string InvoiceCode { get; set; } = "";
        public string SemesterCode { get; set; } = "";
        public string Status { get; set; } = "unpaid"; // unpaid|paid|partial|canceled
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? PaidAtUtc { get; set; }
        public IReadOnlyList<TuitionItem> Items { get; set; } = Array.Empty<TuitionItem>();
        public IReadOnlyList<TuitionPayment> Payments { get; set; } = Array.Empty<TuitionPayment>();
    }
}
