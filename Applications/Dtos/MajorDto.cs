namespace StudentCourseManagement.Applications.Dtos
{
    public sealed class MajorDto
    {
        public Guid Id { get; set; }
    public string MajorName { get; set; } = null!;
        public Guid FacultyId { get; set; }
   public string? FacultyName { get; set; }
    }
}
