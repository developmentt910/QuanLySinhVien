

namespace StudentCourseManagement.Infrastructure.Email
{
    public sealed class EmailServiceStub: IEmailService
    {
        public Task SendAsync(string toEmail, string subject, string body, CancellationToken ct = default)
        {
            MessageBox.Show($"[EMAIL STUB]\nTo: {toEmail}\nSubject: {subject}\n\n{body}", "Email Stub");
            return Task.CompletedTask;
        }

       
    }
}
