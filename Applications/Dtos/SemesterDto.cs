namespace StudentCourseManagement.Applications.Dtos
{
    public sealed class SemesterDto
    {
        public Guid Id { get; set; }
        public string SemesterName { get; set; } = null!;
    public int Year { get; set; }
        public int SemesterNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
     public bool IsActive { get; set; }
        public Guid MajorId { get; set; }
        public string? MajorName { get; set; }
    }
}
