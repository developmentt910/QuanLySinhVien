using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Infrastructure.Captcha
{
    public sealed class StubCaptchaService : ICaptchaService
    {
        private string _currentCaptcha = "";
        public string GenerateCaptcha()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            _currentCaptcha = new string(Enumerable.Repeat(chars, 5)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return _currentCaptcha;
        }

        public bool Verify(string token, string userInput, CancellationToken ct = default)
            => token.Equals(userInput, StringComparison.OrdinalIgnoreCase);
    }
}
