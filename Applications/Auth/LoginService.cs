

namespace StudentCourseManagement.Applications.Auth
{
    public sealed class LoginService
    {
        private readonly IUsersReader _usersR;
        private readonly ThrottleService _throttle;
        private readonly CaptchaVerifier? _captcha;
        private readonly IRosterReader _rosterR;
        private readonly IUsersWriter _userW;


        public LoginService(
            IUsersReader usersR,
            ThrottleService throttle,
            IRosterReader rosterR,
            IUsersWriter userW,
            CaptchaVerifier? captcha = null)
        {
            _usersR = usersR;
            _throttle = throttle;
            _rosterR = rosterR;
            _userW = userW;
            _captcha = captcha;
        }

        public string GenerateCaptcha() => _captcha?.Generate() ?? string.Empty;

        public async Task<Result<User>> LoginAsync(LoginDto dto, CancellationToken ct = default)
        {
            // Kiểm tra Captcha
            if (_captcha != null && !_captcha.Verify(dto.CaptchaToken!, dto.CaptchaInput!))
                return Result<User>.Fail("Mã bảo vệ không đúng.");

            User? user = null;

            //Admin login
            if (!string.IsNullOrWhiteSpace(dto.PrivilegeCode))
            {
                user = await _usersR.FindByPrivilegeCode(dto.PrivilegeCode.Trim());
                if (user == null)
                    return Result<User>.Fail("Tài khoản quản trị không tồn tại.");
               
            }
            // Student login
            else if (!string.IsNullOrWhiteSpace(dto.StudentCode))
            {
                user = await _usersR.FindByStudentCode(dto.StudentCode.Trim());
                if (user == null)
                    return Result<User>.Fail("Tài khoản sinh viên không tồn tại.");
                
                if (string.IsNullOrWhiteSpace(dto.Password))
                    return Result<User>.Fail("Mật khẩu không được để trống.");

                if (!PasswordHasher.Verifier(dto.Password, user.PasswordHash))
                    return Result<User>.Fail("Mật khẩu không đúng.");
            }
            else
            {
                return Result<User>.Fail("Vui lòng nhập mã đặc quyền hoặc mã sinh viên.");
            }

            // Kiểm tra tài khoản bị khóa
            if (user.IsLocked)
                return Result<User>.Fail("Tài khoản đang bị khóa.");

            // Kiểm tra throttle
            var keyHash = KeyHasher.Sha256(Encoding.UTF8.GetBytes(user.Id.ToString()));
            if (!await _throttle.AllowAsync("password", keyHash, DateTime.UtcNow))
                return Result<User>.Fail("Thử sai quá nhiều lần, vui lòng thử lại sau.");

           

            await _throttle.ResetAsync("password", keyHash);

            // Kiểm tra quyền
            if (!string.IsNullOrWhiteSpace(dto.PrivilegeCode) && user.Role != "admin")
                return Result<User>.Fail("Tài khoản này không có quyền quản trị.");
            if (!string.IsNullOrWhiteSpace(dto.StudentCode) && user.Role != "user")
                return Result<User>.Fail("Tài khoản này không phải sinh viên.");

            return Result<User>.Success(user);
        }
    }

}
