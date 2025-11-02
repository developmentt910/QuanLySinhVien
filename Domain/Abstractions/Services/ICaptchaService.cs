

namespace StudentCourseManagement.Domain.Abstractions.Services
{
    public interface ICaptchaService
    {
        bool Verify(string token, string userInput, CancellationToken ct = default);
        string GenerateCaptcha();
    }
}
