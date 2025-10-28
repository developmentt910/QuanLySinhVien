using StudentCourseManagement.Applications.Dtos;
using StudentCourseManagement.Applications.Security;
using StudentCourseManagement.Applications.Validation;
using StudentCourseManagement.Domain.Results;
using StudentCourseManagement.Infrastructure.Security.Crypto;

namespace StudentCourseManagement.Applications.Auth
{
    public sealed class LoginService
    {
        private readonly IUsersReader _usersR;
        private readonly ThrottleService _throttle;
        private readonly CaptchaVerifier? _captcha;

        public LoginService(IUsersReader usersR, ThrottleService throttle, CaptchaVerifier? captcha = null)
        {
            _usersR = usersR;
            _throttle = throttle;
            _captcha = captcha;
        }

        public string GenerateCaptcha() => _captcha?.Generate() ?? string.Empty;

        public async Task<Result<User>> LoginAsync(LoginDto dto)
        {
            if (_captcha != null && !_captcha.Verify(dto.CaptchaToken!, dto.CaptchaInput!))
                return Result<User>.Fail("Mã bảo vệ không đúng.");

            var keyInput = dto.StudentCodeOrEmail.Trim().ToLowerInvariant();
            var user = RegexRules.IsMatch(keyInput, RegexRules.Email)
                ? await _usersR.FindByEmailAsync(keyInput)
                : await _usersR.FindByStudentCode(keyInput);

            if (user == null) return Result<User>.Fail("Tài khoản không tồn tại.");
            if (user.IsLocked) return Result<User>.Fail("Tài khoản đang bị khoá.");
            if (!user.EmailVerified) return Result<User>.Fail("Tài khoản chưa xác minh email.");

            var keyHash = KeyHasher.Sha256(Encoding.UTF8.GetBytes(user.Id.ToString()));
            if (!await _throttle.AllowAsync("password", keyHash, DateTime.UtcNow))
                return Result<User>.Fail("Thử sai quá nhiều lần, vui lòng thử lại sau.");

            if (!PasswordHasher.Verifier(dto.Password, user.PasswordHash))
                return Result<User>.Fail("Mật khẩu không đúng.");

            await _throttle.ResetAsync("password", keyHash);

            return Result<User>.Success(user);
        }
    }
}
