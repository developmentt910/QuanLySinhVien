using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Domain.Abstractions.Services
{
    public interface ICaptchaService
    {
        bool Verify(string token, string userInput, CancellationToken ct = default);
        string GenerateCaptcha();
    }
}
