
namespace StudentCourseManagement.Domain.Abstractions.Services
{
    public interface IClock
    {
        DateTime UtcNow();
    }
}
