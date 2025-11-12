namespace StudentCourseManagement.Domain.Entities
{
    public sealed class Semester
    {
        public Guid Id { get; set; } = Guid.NewGuid();
      public string SemesterName { get; set; } = null!;
     public int Year { get; set; }
      public int SemesterNumber { get; set; } // 1, 2, 3 (h?c k? 1, 2, 3)
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
     public bool IsActive { get; set; } = true;

        // Foreign key
        public Guid MajorId { get; set; }
        public Major Major { get; set; } = null!;
    }
}
