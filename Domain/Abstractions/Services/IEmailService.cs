
namespace StudentCourseManagement.Domain.Abstractions.Services
{
    public interface IEmailService
    {
        Task SendAsync (string toEmail, string subject, string body, CancellationToken ct = default);
    }
}
