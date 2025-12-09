

namespace StudentCourseManagement.Domain.Entities
{
    public sealed class Faculty
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FacultyName { get; set; } = null!;

      
    }
}
