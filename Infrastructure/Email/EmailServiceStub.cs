using StudentCourseManagement.Domain.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
