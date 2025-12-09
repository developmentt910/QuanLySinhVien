namespace StudentCourseManagement.Domain.Entities
{
    public sealed class Semester
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string SemesterCode { get; set; } = null!;
        public string SemesterName { get; set; } = null!;
        public string AcademicYear { get; set; } = null!;
    }
}
