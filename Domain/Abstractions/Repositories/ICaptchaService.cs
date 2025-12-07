namespace StudentCourseManagement.Domain.Abstractions.Repositories
{
    public interface ICaptchaService
    {
        bool Verify(string token, string userInput, CancellationToken ct = default);
        string GenerateCaptcha();
    }
}
