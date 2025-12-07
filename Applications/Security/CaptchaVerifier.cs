using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagement.Applications.Security
{
    public sealed class CaptchaVerifier
    {
        private readonly ICaptchaService _captcha;

        public CaptchaVerifier(ICaptchaService captcha) 
        {
            _captcha = captcha;
        }
        public string Generate()
           => _captcha.GenerateCaptcha();
        public bool Verify(string token, string userInput) 
            => _captcha.Verify(token, userInput);

        
    }
}
